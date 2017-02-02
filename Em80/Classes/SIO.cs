using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em80
{
    public class SerialEventArgs : EventArgs
    {
        public byte data;
    }

    public static partial class EmulatedSystem
    {
        public static sio[] sioPorts = { new sio(), new sio(), new sio(), new sio() };

        public class sio
        {
            public enum sioType { IMSAI_A, IMSAI_B, Altair, DiskJockey, RubeCronUSB, None };

            public EventHandler<SerialEventArgs> serialOut;

            private sioType type = sioType.IMSAI_A;
            private byte inBuff;
            private bool inAvail;
            private byte dataPort;
            private byte statPort;
            private bool ioSubscribed = false;
            private bool djSubscribed = false;

            public sio ()
            {
                setType(sioType.None);
            }

            ~sio()
            {
                if (djSubscribed) DiskJockey.serialOut -= DJOutEventHandler;

                if (ioSubscribed)
                {
                    EmulatedSystem.io.Output -= OutEventHandler;
                    EmulatedSystem.io.Input -= InEventHandler;
                }
            }

            public void setType(sioType t)
            {
                type = t;

                // set port values
                switch (t)
                {
                    case sioType.IMSAI_A:
                        dataPort = 2;
                        statPort = 3;
                        break;

                    case sioType.IMSAI_B:
                        dataPort = 4;
                        statPort = 5;
                        break;

                    case sioType.Altair:
                        dataPort = 0x11;
                        statPort = 0x10;
                        break;

                    case sioType.RubeCronUSB:
                        dataPort = 0x30;
                        statPort = 3;
                        break;
                }

                if (djSubscribed)
                {
                    DiskJockey.serialOut -= DJOutEventHandler;
                    djSubscribed = false;
                }

                if (ioSubscribed)
                {
                    EmulatedSystem.io.Output -= OutEventHandler;
                    EmulatedSystem.io.Input -= InEventHandler;
                    ioSubscribed = false;
                }

                if (type == sioType.DiskJockey)
                {
                    DiskJockey.serialOut += DJOutEventHandler;
                    djSubscribed = true;
                }
                else
                {
                    EmulatedSystem.io.Output += OutEventHandler;
                    EmulatedSystem.io.Input += InEventHandler;
                    ioSubscribed = true;
                }
            }

            private void DJOutEventHandler(object sender, SerialEventArgs e)
            {
                if (serialOut != null)
                {
                    serialOut(sender, e);
                }
            }

            private void OutEventHandler(byte port)
            {
                if (port == dataPort)   // send a byte out
                {
                    if (serialOut != null)
                    {
                        SerialEventArgs e = new SerialEventArgs();
                        e.data = cpu.registers.a;
                        serialOut(null, e);
                    }
                }
            }

            private void InEventHandler(byte port)
            {
                if (port == statPort)       // system is checking uart status
                {
                    switch (type)
                    {
                        case sioType.IMSAI_A:
                        case sioType.IMSAI_B:
                            if (inAvail) EmulatedSystem.cpu.registers.a = 0x03;     // rx ready if a byte is waiting
                            else EmulatedSystem.cpu.registers.a = 0x01;             // tx always ready
                            break;

                        case sioType.Altair:
                            if (inAvail) EmulatedSystem.cpu.registers.a = 0x03;
                            else EmulatedSystem.cpu.registers.a = 0x02;
                            break;

                        case sioType.RubeCronUSB:
                            if (inAvail) EmulatedSystem.cpu.registers.a = 0x00; // (active low)
                            else EmulatedSystem.cpu.registers.a = 0x20;
                            break;
                    }
                }
                else if (port == dataPort)  // system is getting a byte from the uart
                {
                    EmulatedSystem.cpu.registers.a = inBuff;
                    inAvail = false;
                }
            }

            public void serialIn(byte b)
            {
                if (type == sioType.DiskJockey)
                {
                    DiskJockey.serialIn(b);
                }
                else
                {
                    inBuff = b;
                    inAvail = true;
                }
            }
        }
    }
}
