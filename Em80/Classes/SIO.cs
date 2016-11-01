using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em80
{
    public static partial class EmulatedSystem
    {
        public static class sio
        {
            public static event EventHandler<SerialEventArgs> serialOut;

            private static byte inBuff;
            private static bool inAvail;

            public static void Init()
            {
                EmulatedSystem.io.Output += new EmulatedSystem.io.IOEventHandler(OutEventHandler);
                EmulatedSystem.io.Input += new EmulatedSystem.io.IOEventHandler(InEventHandler);
            }

            private static void OutEventHandler(byte port)
            {
                if (port == 2 || port == 17)    // sio port 0
                {
                    if (serialOut != null)
                    {
                        SerialEventArgs e = new SerialEventArgs();
                        e.data = cpu.registers.a;
                        e.port = 0;
                        serialOut(null, e);
                    }
                }
            }

            private static void InEventHandler(byte port)
            {
                switch (port)
                {
                    case 2:  // console data (imsai sio port 0)
                    case 17: // console data (altair sio port 0)
                        EmulatedSystem.cpu.registers.a = inBuff;
                        inAvail = false;
                        break;
                    case 3: // console status (imsai sio)
                        EmulatedSystem.cpu.registers.a = 0x01; // tx always ready
                        if (inAvail) EmulatedSystem.cpu.registers.a |= 0x02;    // rx ready if a byte is waiting
                        break;
                    case 16: // console status (altair sio)
                        EmulatedSystem.cpu.registers.a = 0x02; // tx always ready
                        if (inAvail) EmulatedSystem.cpu.registers.a |= 0x01;    // rx ready if a byte is waiting
                        break;
                }
            }

            public static void serialIn(byte b)
            {
                inBuff = b;
                inAvail = true;
            }
        }
    }
}
