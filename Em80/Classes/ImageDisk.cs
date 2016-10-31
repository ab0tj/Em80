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
            public byte type;
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
        public int sectors;
        public int heads;
        public bool hasChanges;

        public ImageDisk(string fileName)
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
                    int sectorIndex = imgData[head][cyl].sectorMap[s];    // 1-indexed
                    if (sectorIndex > sectors) { sectors = sectorIndex; }
                    sectorIndex--;  // 0-indexed

                    imgData[head][cyl].sectorData[sectorIndex] = new Sector();
                    imgData[head][cyl].sectorData[sectorIndex].type = imgReader.ReadByte();

                    switch (imgData[head][cyl].sectorData[sectorIndex].type)
                    {
                        case 0: // sector unavailable
                            break;

                        case 1: // normal sector record
                        case 3: // normal with deleted address mark
                        case 5: // normal with read error
                        case 7: // normal, deleted, read error
                            imgData[head][cyl].sectorData[sectorIndex].data = imgReader.ReadBytes(secSz);
                            break;

                        case 2: // compressed sector record
                        case 4: // compressed with deleted address mark
                        case 6: // compressed with read error
                        case 8: // compressed, deleted, read error
                            imgData[head][cyl].sectorData[sectorIndex].data = Enumerable.Repeat(imgReader.ReadByte(), secSz).ToArray();  // uncompressed
                            break;

                        default:    // ??
                            throw new Exception("Encountered unsupported sector type");
                    }
                }
            }

            cylinders++;
            heads++;

            imgReader.Close();
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

        public string getTypeString(byte cyl, byte head, byte sec)
        {
            sec--;
            switch (imgData[head][cyl].sectorData[sec].type)
            {
                case 0:
                    return "Unreadable";
                case 1:
                    return "Normal";
                case 2:
                    return "Compressed";
                case 3:
                    return "Normal, deleted";
                case 4:
                    return "Compressed, deleted";
                case 5:
                    return "Normal, read error";
                case 6:
                    return "Compressed, read error";
                case 7:
                    return "Normal, deleted, read error";
                case 8:
                    return "Compressed, deleted, read error";
                default:
                    return "Unknown type";
            }
        }

        public Sector getSector(byte cyl, byte head, byte sec)
        {
            sec--;
            return imgData[head][cyl].sectorData[sec];
        }
    }
}
