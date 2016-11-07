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
                public bool preview;
            }

            public static event EventHandler<MMIOEventArgs> MMIOWrite;
            public static event EventHandler<MMIOEventArgs> MMIORead;

            public static void clear()
            {
                for (int a = 0; a < 65536; a++)
                {
                    if (byteInfo[a] == memByteType.ram) bytes[a] = 0;
                }
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
                        e.preview = preview;
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

            public static void copyIn(int addr, byte[] data, bool rom = false)
            {
                if (addr + data.Length > 65536) data = data.Take(data.Length - ((addr + data.Length) - 65535)).ToArray();   // avoid going past the end of memory

                for (int a = 0; a < data.Length; a++)
                {
                    int ad = addr + a;
                    if (byteInfo[ad] == memByteType.ram || (byteInfo[ad] == memByteType.rom && rom))
                    {
                        bytes[ad] = data[a];
                        if (rom) byteInfo[ad] = memByteType.rom;
                    }
                }
            }

            public static void writeProtect(int addr, int len = 1)
            {
                for (int a = addr; a < addr + len; a++)
                {
                    if (byteInfo[a] == memByteType.ram) byteInfo[a] = memByteType.rom;
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

            public static string getMap()
            {
                string map = "";
                int startAddr = 0;

                for (int a = 0; a < 65536; a++)
                {
                    if (a == 65535 || byteInfo[a] != byteInfo[a + 1])
                    {
                        map += startAddr.ToString("X4") + "-" + a.ToString("X4") + ": ";

                        switch (byteInfo[a])
                        {
                            case memByteType.ram:
                                map += "RAM\n";
                                break;

                            case memByteType.rom:
                                map += "ROM\n";
                                break;

                            case memByteType.mmio:
                                map += "MMIO\n";
                                break;
                        }

                        startAddr = a + 1;
                    }
                }

                return map.TrimEnd();
            }
        }
    }
}
