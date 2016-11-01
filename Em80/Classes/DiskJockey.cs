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
            public static event EventHandler<SerialEventArgs> serialOut;

            private static byte serialInBuff;
            private static bool serialInAvail;

            private static ushort romBase;
            private static ushort mmioBase;
            private static ushort ramBase;

            private class Disks
            {
                public static ImageDisk disk1;
                public static ImageDisk disk2;
                public static ImageDisk disk3;
                public static ImageDisk disk4;
            }

            public static void Init(ushort addr)
            {
                if (addr == 0xe000)
                {
                    Hex.LoadIntoMem(new MemoryStream(Properties.Resources.DiskJockey_E000), false);  // load firmware into memory
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
                ramBase = (ushort)(romBase + 0x400);

                memory.writeProtect(romBase, 0x3f8);    // hex file doesn't write protect the whole ROM area, so do it manually
                memory.addMmio(mmioBase, 8);
                memory.MMIORead += new EventHandler<memory.MMIOEventArgs>(MMIOReadHandler);
                memory.MMIOWrite += new EventHandler<memory.MMIOEventArgs>(MMIOWriteHandler);
            }

            private static void MMIOReadHandler(object sender, memory.MMIOEventArgs e)
            {
                switch (e.addr - mmioBase)
                {
                    case 0: // inverted UART data output register
                        e.val = serialInBuff;
                        serialInAvail = false;
                        break;

                    case 1: // inverted UART status register
                        e.val = 0xf7;   // tx always ready
                        if (serialInAvail) e.val &= 0xfb;   // set DR bit to zero
                        break;
                }
            }

            private static void MMIOWriteHandler(object sender, memory.MMIOEventArgs e)
            {
                switch (e.addr - mmioBase)
                {
                    case 0:
                        if (serialOut != null)
                        {
                            SerialEventArgs ev = new SerialEventArgs();
                            ev.data = (byte)~e.val;
                            ev.port = 0;
                            serialOut(null, ev);
                        }
                        break;


                }
            }

            public static void serialIn(byte b)
            {
                serialInBuff = (byte)~b;    // "inverted" uart bus
                serialInAvail = true;
            }
        }
    }
}
