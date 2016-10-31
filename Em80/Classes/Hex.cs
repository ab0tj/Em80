using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Em80
{
    static class Hex
    {
        public static void LoadIntoMem(string theFileName, bool loadAsRom)
        {
            using (StreamReader sr = new StreamReader(theFileName))
            {
                byte type = 0;

                while (type != 1)   // loop through hex file
                {
                    while (true)                    // look for start code
                    {
                        int a = sr.Read();
                        if (a == ':') break;
                        if (a == -1) throw new Exception("Unexpected end of file");
                    }

                    byte count = GetNextByte(sr);    // byte count
                    byte cksum = count;

                    byte addrHi = GetNextByte(sr);   // address high byte
                    cksum += addrHi;

                    byte addrLo = GetNextByte(sr);   // address low byte
                    cksum += addrLo;

                    type = GetNextByte(sr);     // record type
                    cksum += type;

                    if (type != 0 || count == 0) continue;    // no data to read

                    byte[] buff = new byte[count];  // buffer to hold translated line

                    for (int i = 0; i < count; i++) // get the bytes
                    {
                        buff[i] = GetNextByte(sr);
                        cksum += buff[i];
                    }

                    cksum += GetNextByte(sr);      // checksum from record
                    if (cksum != 0) throw new Exception("Invalid checksum");

                    EmulatedSystem.memory.copyIn((addrHi << 8) + addrLo, buff, loadAsRom);
                }
            }
        }

        private static byte GetNextByte(StreamReader sr)
        {
            char[] buff = new char[2];
            sr.ReadBlock(buff, 0, 2);
            return Convert.ToByte(new string(buff), 16);
        }
    }
}
