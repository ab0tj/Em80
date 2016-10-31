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
            enum memByteType : byte { ram, rom, mmio };
            private static byte[] bytes = new byte[65536];
            private static memByteType[] byteInfo = new memByteType[65536];

            public class MMIOEventArgs : EventArgs
            {
                public int addr;
                public byte val = 0xff;
            }

            public static event EventHandler<MMIOEventArgs> MMIOWrite;
            public static event EventHandler<MMIOEventArgs> MMIORead;

            public static void clear()
            {
                bytes = new byte[65536];
            }

            public static byte read(int addr, bool preview = false)
            {
                if (byteInfo[addr] != memByteType.mmio)
                {
                    return bytes[addr];
                }
                else
                {
                    if (MMIORead != null)
                    {
                        MMIOEventArgs e = new MMIOEventArgs();
                        e.addr = addr;
                        MMIORead(null, e);
                        return e.val;
                    }
                    else
                    {
                        return 0xff;
                    }
                }
            }

            public static void write(ushort addr, byte data)
            {
                if (byteInfo[addr] == memByteType.ram)
                {
                    bytes[addr] = data;
                }
                else if (byteInfo[addr] == memByteType.mmio)
                {
                    if (MMIOWrite != null)
                    {
                        MMIOEventArgs e = new MMIOEventArgs();
                        e.addr = addr;
                        e.val = data;
                        MMIOWrite(null, e);
                    }
                }
            }

            public static ushort get_16()
            {
                ushort val;
                val = read(cpu.registers.pc++);
                val |= (ushort)(read(cpu.registers.pc++) << 8);
                return val;
            }

            public static ushort pop()
            {
                ushort val;
                val = read(cpu.registers.sp++);
                val |= (ushort)(read(cpu.registers.sp++) << 8);
                return val;
            }

            public static void push(ushort val)
            {
                write(--cpu.registers.sp, (byte)(val >> 8));
                write(--cpu.registers.sp, (byte)val);
            }

            public static void copyIn(int addr, byte[] data, bool ro = false)
            {
                if (addr + data.Length > 65535) data = data.Take(data.Length - ((addr + data.Length) - 65535)).ToArray();   // avoid going past the end of memory

                for (ushort a = 0; a < data.Length; a++)
                {
                    int ad = addr + a;
                    if (byteInfo[ad] == memByteType.ram || ro)
                    {
                        bytes[ad] = data[a];
                        if (ro) byteInfo[ad] = memByteType.rom;
                    }
                }
            }

            public static void addMmio(ushort addr, ushort len = 1)
            {
                for (ushort a = addr; a < addr + len; a++)
                {
                    byteInfo[a] = memByteType.mmio;
                }
            }

            public static byte[] getArray()
            {
                byte[] temp = new byte[65536];

                for (int a = 0; a < 65536; a++) temp[a] = read(a, true);

                return temp;
            }
        }
    }
}
