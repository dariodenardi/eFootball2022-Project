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
    class CountryController
    {
        private static readonly string FILE_NAME = "/Country.bin";
        private static readonly int BLOCK = 1420;

        public CountryController()
        {
            CountryTable = new DataTable();
            CountryTable.Columns.Add("Index", typeof(int));
            CountryTable.Columns.Add("Name", typeof(string));
        }

        private MemoryStream MemoryCountry { get; set; }
        private BinaryReader ReadCountry { get; set; }
        private BinaryWriter WriteCountry { get; set; }
        public DataTable CountryTable { get; set; }

        private MemoryStream UnzlibFile(string patch)
        {
            MemoryStream memoryCountry = null;

            byte[] file = File.ReadAllBytes(patch + FILE_NAME);
            byte[] ss1 = Unzlib.UnZlibFilePC(file);
            memoryCountry = new MemoryStream(ss1);

            return memoryCountry;
        }

        public int Load(string patch)
        {
            MemoryCountry = UnzlibFile(patch);

            int countryNumber = (int)MemoryCountry.Length / BLOCK;

            if (countryNumber == 0)
                return 0;

            string countryName;
            try
            {
                ReadCountry = new BinaryReader(MemoryCountry);
                long START = 1278; // country name offset

                for (int i = 0; i < countryNumber; i++)
                {
                    MemoryCountry.Seek(START, SeekOrigin.Begin);
                    countryName = Encoding.UTF8.GetString(ReadCountry.ReadBytes(70)).TrimEnd('\0');

                    CountryTable.Rows.Add(i, countryName);

                    START += BLOCK;
                }
                WriteCountry = new BinaryWriter(MemoryCountry);
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public Country LoadCountry(int index)
        {
            Country country;

            uint countryID;
            string countryName;
            try
            {
                ReadCountry.BaseStream.Position = index * BLOCK + 1278;
                countryName = Encoding.UTF8.GetString(ReadCountry.ReadBytes(70)).TrimEnd('\0');

                ReadCountry.BaseStream.Position = index * BLOCK;
                uint aux1 = ReadCountry.ReadUInt32();
                countryID = aux1 << 13;
                countryID = countryID >> 23;

                country = new Country((ushort)countryID);
                country.Name = countryName;
            }
            catch (Exception)
            {
                return null;
            }

            return country;
        }

        public int LoadCountryByID(ushort countryID)
        {
            int countryNumber = (int)MemoryCountry.Length / BLOCK;

            ReadCountry.BaseStream.Position = 0;
            for (int i = 0; i < countryNumber; i++)
            {
                uint block1 = ReadCountry.ReadUInt32();
                block1 = block1 << 13;
                block1 = block1 >> 23;
                if (countryID == (ushort)block1)
                    return i;

                ReadCountry.BaseStream.Position += BLOCK - 4;
            }

            return -1;
        }

        public void CloseMemory()
        {
            if (MemoryCountry != null)
            {
                MemoryCountry.Close();
                ReadCountry.Close();
                WriteCountry.Close();
                CountryTable.Rows.Clear();
            }
        }

    }
}
