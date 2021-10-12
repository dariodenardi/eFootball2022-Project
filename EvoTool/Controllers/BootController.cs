using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvoTool.Models;
using EvoTool.ZlibUnzlib;
using System.IO;
using System.Data;

namespace EvoTool.Controllers
{
    class BootController
    {
        private static readonly string FILE_NAME = "/Boots.bin";
        private static readonly int BLOCK = 304;

        public BootController()
        {
            BootTable = new DataTable();
            BootTable.Columns.Add("Index", typeof(int));
            BootTable.Columns.Add("Name", typeof(string));
        }

        public MemoryStream MemoryBoot { get; set; }
        public BinaryReader ReadBoot { get; set; }
        public BinaryWriter WriteBoot { get; set; }
        public DataTable BootTable { get; set; }

        private MemoryStream UnzlibFile(string patch)
        {
            MemoryStream memoryBoot = null;

            byte[] file = File.ReadAllBytes(patch + FILE_NAME);
            byte[] ss1 = Unzlib.UnZlibFilePC(file);
            memoryBoot = new MemoryStream(ss1);

            return memoryBoot;
        }

        public int Load(string patch)
        {
            MemoryBoot = UnzlibFile(patch);

            int bootNumber = (int)MemoryBoot.Length / BLOCK;

            if (bootNumber == 0)
                return 0;

            string bootName;
            try
            {
                ReadBoot = new BinaryReader(MemoryBoot);
                long START = 204; // boot name offset

                for (int i = 0; i < bootNumber; i++)
                {
                    MemoryBoot.Seek(START, SeekOrigin.Begin);
                    bootName = Encoding.UTF8.GetString(ReadBoot.ReadBytes(100)).TrimEnd('\0');

                    BootTable.Rows.Add(i, bootName);

                    START += BLOCK;
                }
                WriteBoot = new BinaryWriter(MemoryBoot);
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public Boot LoadBoot(int index)
        {
            Boot boot;

            UInt16 bootId;
            byte order;
            string bootName;
            try
            {
                ReadBoot.BaseStream.Position = index * BLOCK + 204;
                bootName = Encoding.UTF8.GetString(ReadBoot.ReadBytes(100)).TrimEnd('\0');

                ReadBoot.BaseStream.Position = index * BLOCK;
                bootId = ReadBoot.ReadUInt16();

                ReadBoot.BaseStream.Position = index * BLOCK + 2;
                order = ReadBoot.ReadByte();

                boot = new Boot(bootId);
                boot.Name = bootName;
                boot.Order = order;
            }
            catch (Exception)
            {
                return null;
            }

            return boot;
        }

        public int LoadBootById(UInt16 bootId)
        {
            int bootNumber = (int)MemoryBoot.Length / BLOCK;

            ReadBoot.BaseStream.Position = 0;
            for (int i = 0; i < bootNumber; i++)
            {
                if (bootId == ReadBoot.ReadUInt16())
                    return 1;

                ReadBoot.BaseStream.Position += BLOCK - 2;
            }

            return 0;
        }

        public int ApplyBoot(int index, Boot boot)
        {
            try
            {
                int offsetBase = BLOCK * index;
                WriteBoot.BaseStream.Position = offsetBase;
                byte zero = 0;

                UInt16 id = boot.Id;
                byte order = boot.Order;
                string bootName = boot.Name;
                WriteBoot.Write(id);
                WriteBoot.Write(order);
                for (int i = 0; i <= 100; i++)
                {
                    WriteBoot.Write(zero);
                }

                WriteBoot.BaseStream.Position = offsetBase + 204;
                WriteBoot.Write(bootName.ToCharArray());
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public int Save(string patch)
        {
            try
            {
                byte[] ss13 = Zlib.ZlibFilePC(MemoryBoot.ToArray());
                File.WriteAllBytes(patch + FILE_NAME, ss13);
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public void CloseMemory()
        {
            if (MemoryBoot != null)
            {
                MemoryBoot.Close();
                ReadBoot.Close();
                WriteBoot.Close();
            }
        }
    }
}
