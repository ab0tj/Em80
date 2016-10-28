using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Em80
{
    public static partial class EmulatedSystem
    {
        public static class memory
        {
            public static byte[] bytes = new byte[65536];

            public static void init()
            {
                bytes = new byte[65536];
            }

            public static ushort get_16()
            {
                ushort val;
                val = memory.bytes[cpu.registers.pc++];
                val |= (ushort)(memory.bytes[cpu.registers.pc++] << 8);
                return val;
            }

            public static ushort pop()
            {
                ushort val;
                val = memory.bytes[cpu.registers.sp++];
                val |= (ushort)(memory.bytes[cpu.registers.sp++] << 8);
                return val;
            }

            public static void push(ushort val)
            {
                memory.bytes[--cpu.registers.sp] = (byte)(val >> 8);
                memory.bytes[--cpu.registers.sp] = (byte)val;
            }
        }
    }
}
