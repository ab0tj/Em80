using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em80
{
    public static partial class EmulatedSystem 
    {
        public static class io
        {
            public static frmConsole formConsole = new frmConsole();

            public static class Keyboard
            {
                private static byte[] buff = new byte[32];  // implement a 32-byte circular buffer
                private static int head;
                private static int tail;
                public static bool byte_aval
                {
                    get { return head != tail; }
                }
                public static void KeyPress(byte val)   // add key to the buffer
                {
                    int next = (head + 1) % 32;
                    if (next != tail)
                    {
                        buff[head] = val;
                        head = next;
                    }
                }

                public static byte GetKey()     // get key from the buffer
                {
                    if (!byte_aval) return 0;

                    byte val = buff[tail];
                    tail = (tail + 1) % 32;
                    return val;
                }
            }



            public static void o(byte port)    // output to "port"
            {
                if (port == 2 || port == 17)  // console data
                {
                    formConsole.WriteToConsole(cpu.registers.a);
                }
            }

            public static void i(byte port)     // input from "port"
            {
                switch (port)
                {
                    case 2:  // console data (imsai sio)
                    case 17: // console data (altair sio)
                        cpu.registers.a = Keyboard.GetKey();
                        break;
                    case 3: // console status (imsai sio)
                        cpu.registers.a = 0x01; // tx always ready
                        if (Keyboard.byte_aval) cpu.registers.a |= 0x02;    // rx ready if a char is waiting
                        break;
                    case 16: // console status (altair sio)
                        cpu.registers.a = 0x02; // tx always ready
                        if (Keyboard.byte_aval) cpu.registers.a |= 0x01;    // rx ready if a char is waiting
                        break;
                    default:    // something else
                        cpu.registers.a = 0;
                        break;
                }
            }
        }
    }
}
