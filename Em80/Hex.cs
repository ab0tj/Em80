using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Em80
{
    static class Hex
    {
        public static void LoadIntoMem(string theFileName)
        {
            try
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
                            if (a == -1)
                            {
                                MessageBox.Show("Unexpected end of file", "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
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
                        if (cksum != 0)
                        {
                            MessageBox.Show("Invalid checksum", "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        buff.CopyTo(emulatedSystem.memory.bytes, (addrHi << 8) + addrLo);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
