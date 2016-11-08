using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Em80
{
    public class ImageDisk
    {
        public class Sector
        {
            public bool deleted;
            public bool error;
            public byte[] data;
        }

        struct Track
        {
            public byte mode;
            public byte sectors;
            public byte[] sectorMap;
            public Sector[] sectorData;
        }

        Track[][] imgData;

        public string header;
        public string comment;
        public int cylinders;
        public int heads;
        public bool ready;
        public bool hasChanges;

        public void loadImage(string fileName)
        {
            imgData = new Track[2][];
            imgData[0] = new Track[80];
            imgData[1] = new Track[80];

            BinaryReader imgReader = new BinaryReader(File.Open(fileName, FileMode.Open));

            header = System.Text.Encoding.Default.GetString(imgReader.ReadBytes(28));

            if (header.Substring(0, 4) != "IMD ") throw new Exception("File is not ImageDisk format.");

            imgReader.ReadBytes(2);     // skip CrLf

            byte a = 0;
            while ((a = imgReader.ReadByte()) != 0x1a)  // comment
            {
                comment += (char)a;
            }
            comment = comment.Trim();

            while (imgReader.BaseStream.Position != imgReader.BaseStream.Length)    // loop through tracks (to EOF)
            {
                byte mode = imgReader.ReadByte();
                byte cyl = imgReader.ReadByte();
                byte head = imgReader.ReadByte();
                byte secs = imgReader.ReadByte();
                int secSz = (int)Math.Pow(2, imgReader.ReadByte() + 7);

                if (head > 1 || cyl > 79) throw new Exception("Image uses unsupported features.");

                if (head > heads) { heads = head; }
                if (cyl > cylinders) { cylinders = cyl; }

                imgData[head][cyl].mode = mode;
                imgData[head][cyl].sectors = secs;
                imgData[head][cyl].sectorData = new Sector[secs];
                imgData[head][cyl].sectorMap = imgReader.ReadBytes(secs);

                for (int s = 0; s < secs; s++)   // loop through sector data records
                {
                    int sectorIndex = imgData[head][cyl].sectorMap[s] - 1;    // map is 1-indexed

                    imgData[head][cyl].sectorData[sectorIndex] = new Sector();
                    byte type = imgReader.ReadByte();

                    if (type != 0)  // 0 = unavailable
                    {
                        type--;

                        if ((type & 0x01) == 0)
                        {
                            imgData[head][cyl].sectorData[sectorIndex].data = imgReader.ReadBytes(secSz);   // uncompressed
                        }
                        else
                        {
                            imgData[head][cyl].sectorData[sectorIndex].data = Enumerable.Repeat(imgReader.ReadByte(), secSz).ToArray();  // compressed
                        }

                        if ((type & 0x02) == 1) imgData[head][cyl].sectorData[sectorIndex].deleted = true;  // deleted mark
                        if ((type & 0x04) == 1) imgData[head][cyl].sectorData[sectorIndex].error = true;    // erased mark
                    }
                    else imgData[head][cyl].sectorData[sectorIndex].error = true;
                }
            }

            cylinders++;
            heads++;

            imgReader.Close();

            ready = true;
        }

        public string getModeString(byte cyl, byte head)
        {
            switch (imgData[head][cyl].mode)
            {
                case 0:
                    return "500 kbps FM";
                case 1:
                    return "300 kbps FM";
                case 2:
                    return "250 kbps FM";
                case 3:
                    return "500 kbps MFM";
                case 4:
                    return "300 kbps MFM";
                case 5:
                    return "250 kbps MFM";
                default:
                    return "unknown mode";
            }
        }

        public Sector getSector(byte cyl, byte head, byte sec)
        {
            sec--;
            try
            {
                return imgData[head][cyl].sectorData[sec];
            }
            catch
            {
                return null;
            }
        }

        public int getSectorSize(byte cyl, byte head, byte sec)
        {
            sec--;
            try
            {
                return imgData[head][cyl].sectorData[sec].data.Length;
            }
            catch
            {
                return -1;
            }
        }

        public byte getNumSectors(byte cyl, byte head)
        {
            return imgData[head][cyl].sectors;
        }
    }
}
