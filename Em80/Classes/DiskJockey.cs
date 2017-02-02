using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em80
{
    public static partial class EmulatedSystem
    {
        public static class DiskJockey
        {
            /* Event that serial "devices" can attach to */
            public static event EventHandler<SerialEventArgs> serialOut;

            /* Stuff to keep track of the UART */
            private static byte serialInBuff = 0;
            private static bool serialInAvail;

            /* Where in memory we're putting DiskJockey stuff */
            private static ushort romBase;
            private static ushort mmioBase;

            /* 1791 controller registers */
            private static class registers
            {
                public static byte track;
                public static byte sector;
                public static byte data;
                public static byte status;
            }

            /* 1791 emulation status */
            private static class status
            {
                public static bool busy;    // processing a command
                public static bool read;    // reading a sector
                public static bool write;   // writing a sector
                public static bool multisect;   // multi-sector read or write
                public static bool direction;   // 0 = out, 1 = in
                public static bool index;   // index pulse
                public static bool resetbusy;   // reset busy after status is read
            }

            /* More stuff to keep track of during emulation */
            private static byte selectedDrive = 0;
            private static byte selectedHead = 0;
            private static int sectorPos = 0;

            /* Disk data */
            private static ImageDisk.Sector sectorBuff;
            private static ImageDisk[] drives = new ImageDisk[4];
            private static ImageDisk currentDrive { get { return drives[selectedDrive]; } }

            public static void Init(ushort addr)
            {
                /* Load firmware into memory */
                if (addr == 0xe000)
                {
                    Hex.LoadIntoMem(new MemoryStream(Properties.Resources.DiskJockey_E000), false);
                }
                else if (addr == 0xf800)
                {
                    Hex.LoadIntoMem(new MemoryStream(Properties.Resources.DiskJockey_F800), false);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }

                romBase = addr;
                mmioBase = (ushort)(romBase + 0x3f8);

                memory.writeProtect(romBase, 0x3f8);    // hex file doesn't write protect the whole ROM area, so do it manually

                /* Set up MMIO */
                memory.addMmio(mmioBase, 8);
                memory.MMIORead += new EventHandler<memory.MMIOEventArgs>(MMIOReadHandler);
                memory.MMIOWrite += new EventHandler<memory.MMIOEventArgs>(MMIOWriteHandler);

                /* Reset the 1791 */
                resetController();

                /* Attach some drives */
                for (int i=0; i < drives.Length; i++)
                {
                    drives[i] = new ImageDisk();
                }
            }

            public static void insertDisk(int drive, string fileName)
            {
                drives[drive].loadImage(fileName);
            }

            private static void MMIOReadHandler(object sender, memory.MMIOEventArgs e)
            {
                /* Processes a read from MMIO ports */
                switch (e.addr - mmioBase)
                {
                    case 0: // inverted UART data output register
                        e.val = serialInBuff;
                        if (!e.preview) serialInAvail = false;
                        break;

                    case 1: // inverted UART status register
                        e.val = 0xf7;   // tx always ready
                        if (serialInAvail) e.val &= 0xfb;   // set DR bit to zero
                        break;

                    case 2: // Disk Jockey status register
                        e.val = 0x09;  // bit 0: head
                        if (status.busy) e.val |= 0x02;   // bit 1: datarq
                        // bit 2: intrq
                        if (currentDrive.heads == 2 && currentDrive.ready) e.val &= 0xf7; // bit 3: n2sided

                        if (!e.preview) status.index = !status.index;
                        if (status.index) e.val |= 0x10;  // set index bit

                        if (drives[selectedDrive].ready) e.val |= 0x80; // bit 7: ready
                        break;

                    case 4: // 1791 controller status register
                        e.val = registers.status;
                        if (status.busy) e.val |= 1;    // set busy bit

                        if (status.resetbusy && !e.preview)
                        {
                            status.busy = false; // not busy anymore. firmware checks for busy after issuing some commands.             
                            status.resetbusy = false;
                        }
                                    
                        break;

                    case 5: // 1791 track register
                        e.val = registers.track;
                        break;

                    case 6: // 1791 sector register
                        e.val = registers.sector;
                        break;

                    case 7: // 1791 data register
                        if (status.read) e.val = readByte(e.preview);
                        break;
                }
            }

            private static void MMIOWriteHandler(object sender, memory.MMIOEventArgs e)
            {
                /* Processes a write to MMIO ports */
                switch (e.addr - mmioBase)
                {
                    case 0: // inverted UART data input register
                        if (serialOut != null)
                        {
                            SerialEventArgs ev = new SerialEventArgs();
                            ev.data = (byte)~e.val;
                            serialOut(null, ev);
                        }
                        break;

                    case 1: // disk jockey drive control register
                        if ((e.val & 0x01) == 0) selectedDrive = 0;         // bit 0: drive1
                        else if ((e.val & 0x02) == 0) selectedDrive = 1;    // bit 1: drive2
                        else if ((e.val & 0x04) == 0) selectedDrive = 2;    // bit 2: drive3
                        else if ((e.val & 0x08) == 0) selectedDrive = 3;    // bit 3: drive4

                        if ((e.val & 0x10) == 0) selectedHead = 1;  // bit 4: side 0
                        else selectedHead = 0;

                        // bit 5: intdsbl
                        // bit 6: aenbl
                        if ((e.val & 0x80) == 1) resetController();
                        break;

                    /* case 2: disk jockey function register (not necessary for emulated system) */

                    case 4: // 1791 controller command register
                        doCommand(e.val);
                        break;

                    case 5: // 1791 track register
                        registers.track = e.val;
                        break;

                    case 6: // 1791 sector register
                        registers.sector = e.val;
                        break;

                    case 7: // 1791 data register
                        registers.data = e.val;
                        if (status.write) writeByte(e.val);
                        break;
                }
            }

            public static void serialIn(byte b)
            {
                /* Processes a byte coming in from a serial "device" */
                serialInBuff = (byte)~b;    // "inverted" uart bus
                serialInAvail = true;
            }

            public static void resetController()
            {
                /* Reset the virtual 1791 */
                status.busy = false;
                status.read = false;
                status.write = false;
                registers.track = 0;
                registers.status = 0;
                registers.sector = 0;
            }

            private static void loadSector()
            {
                sectorBuff = drives[selectedDrive].getSector(registers.track, selectedHead, registers.sector);   // get the sector from the image
                sectorPos = 0;

                if (sectorBuff == null || sectorBuff.deleted)
                {
                    registers.status |= 0x10;
                }
                else
                {
                    registers.status &= 0xef;
                }
            }

            private static byte readByte(bool preview)
            {
                /* Read next byte during a sector read command.
                 * Assumes sector was already read into the buffer */
                byte b = sectorBuff.data[sectorPos];

                if (!preview && ++sectorPos == sectorBuff.data.Length)  // this was the last byte
                {
                    if (sectorBuff.error)
                    {
                        registers.status |= 0x08;   // crc error
                        status.read = false;        // abort command
                        status.busy = false;
                        registers.status &= 0xfd;   // drq off
                    }
                    else if (status.multisect)
                    {
                        registers.sector++;     // move to next sector
                        loadSector();
                    }
                    else
                    {
                        status.read = false;    // done
                        status.busy = false;
                        registers.status &= 0xfd;   // drq off
                    }
                }

                return b;
            }

            private static void writeByte(byte data)
            {
                /* Write a byte into the sector buffer.
                 * Assumes the buffer has been set up for us already and the byte is in data register. */
                sectorBuff.data[sectorPos++] = data;

                if (sectorPos == sectorBuff.data.Length)    // last byte
                {
                    currentDrive.putSector(registers.track, selectedHead, registers.sector, sectorBuff);
                    
                    if (status.multisect)
                    {
                        registers.sector++;
                        sectorBuff = new ImageDisk.Sector();
                        sectorBuff.data = new byte[currentDrive.getSectorSize(registers.track, selectedHead, registers.sector)];
                        sectorPos = 0;
                    }
                    else
                    {
                        status.write = false;
                        status.busy = false;
                        registers.status &= 0xfd;   // drq off
                    }
                }
            }

            private static void doCommand(byte c)
            {
                /* Process a write to the command register */
                status.busy = true;

                switch (c & 0xe0)
                {
                    case 0x00:  // restore or seek
                        status.direction = (registers.data > registers.track);
                        if ((c & 0x10) == 0) registers.track = 0;   // restore
                        else registers.track = registers.data;      // seek
                        setType1Flags();
                        break;

                    case 0x20:  // step
                        if (status.direction) registers.track++;    // step in
                        else registers.track--; // step out
                        setType1Flags();
                        break;

                    case 0x40:  // step in
                        status.direction = true;
                        registers.track++;
                        setType1Flags();
                        break;

                    case 0x60:  // step out
                        status.direction = false;
                        registers.track--;
                        setType1Flags();
                        break;

                    case 0x80:  // read
                        status.multisect = (c & 0x10) == 0x10;
                        loadSector();
                        status.read = true;
                        registers.status = 0x02;    // drq
                        break;

                    case 0xa0:  // write
                        status.multisect = (c & 0x10) == 0x10;
                        sectorBuff = new ImageDisk.Sector();
                        sectorBuff.data = new byte[currentDrive.getSectorSize(registers.track, selectedHead, registers.sector)];
                        sectorPos = 0;
                        status.write = true;
                        registers.status = 0x02;
                        break;

                    case 0xc0:  // read address or force interrupt
                        if ((c & 0x10) == 0x10)
                        {     // force interrupt
                            status.busy = false;
                            status.read = false;
                            status.write = false;
                            registers.status &= 0xfd;   // clear drq
                        }
                        else
                        {   // read address
                            if (registers.sector > currentDrive.getNumSectors(registers.track, selectedHead)) registers.sector = 1;
                            sectorBuff = new ImageDisk.Sector();
                            sectorBuff.data = getHeader();

                            if (sectorBuff.data == null)
                            {
                                registers.status |= 0x80;
                                status.busy = false;
                                break;
                            }
                            else
                            {
                                registers.status = 0x02;
                            }

                            sectorPos = 0;
                            status.read = true;
                        }
                        break;

                    case 0xe0:  // read or write track

                        break;
                }
            }

            private static void setType1Flags()
            {
                if (registers.track == 0)
                {
                    registers.status = 0x04;
                }
                else
                {
                    registers.status = 0;
                }

                status.resetbusy = true;
            }

            private static byte[] getHeader()
            {
                int s = currentDrive.getSectorSize(registers.track, selectedHead, registers.sector);
                if (s == -1)
                {
                    return null;
                }

                byte[] h = new byte[6];

                h[0] = registers.track;
                h[1] = selectedHead;
                h[2] = registers.sector;

                switch (s)
                {
                    case 128:
                        h[3] = 0;
                        break;
                    case 256:
                        h[3] = 1;
                        break;
                    case 512:
                        h[3] = 2;
                        break;
                    case 1024:
                        h[3] = 3;
                        break;
                }

                return h;
            }
        }
    }
}
