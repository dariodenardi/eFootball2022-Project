using EvoTool.Models;
using EvoTool.ZlibUnzlib;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoTool.Controllers
{
    class CoachController
    {
        private static readonly string FILE_NAME = "/Coach.bin";
        private static readonly int BLOCK = 0xA0; //160

        public CoachController()
        {
            CoachTable = new DataTable();
            CoachTable.Columns.Add("Index", typeof(int));
            CoachTable.Columns.Add("Name", typeof(string));
        }

        private MemoryStream MemoryCoach { get; set; }
        private BinaryReader ReadCoach { get; set; }
        private BinaryWriter WriteCoach { get; set; }
        public DataTable CoachTable { get; set; }

        private MemoryStream UnzlibFile(string patch)
        {
            MemoryStream memorycoach = null;

            byte[] file = File.ReadAllBytes(patch + FILE_NAME);
            byte[] ss1 = Unzlib.UnZlibFilePC(file);
            memorycoach = new MemoryStream(ss1);

            return memorycoach;
        }

        public int Load(string patch)
        {
            MemoryCoach = UnzlibFile(patch);

            int coachNumber = (int)MemoryCoach.Length / BLOCK;

            if (coachNumber == 0)
                return 0;

            string coachName;
            try
            {
                ReadCoach = new BinaryReader(MemoryCoach);
                long START = -52; // coach name length

                for (int i = 0; i < coachNumber; i++)
                {
                    START += BLOCK;
                    MemoryCoach.Seek(START, SeekOrigin.Begin);
                    coachName = Encoding.UTF8.GetString(ReadCoach.ReadBytes(51)).TrimEnd('\0');

                    CoachTable.Rows.Add(i, coachName);
                }
                WriteCoach = new BinaryWriter(MemoryCoach);
            }
            catch (Exception)
            {
                return 1;
            }
            return 0;
        }

        public Coach LoadCoach(int index)
        {
            Coach coach;

            uint coachId;
            string coachName;
            string coachChineseName;
            string coachJapaneseName;
            ushort countryId;
            try
            {
                ReadCoach.BaseStream.Position = index * BLOCK;
                coachId = ReadCoach.ReadUInt32();

                ReadCoach.BaseStream.Position = index * BLOCK + 8;
                ushort aux1 = ReadCoach.ReadUInt16();
                countryId = (ushort)(aux1 << 7);
                countryId = (ushort)(countryId >> 7);

                ReadCoach.BaseStream.Position = index * BLOCK + 0x6c;
                coachName = Encoding.UTF8.GetString(ReadCoach.ReadBytes(0x33)).TrimEnd('\0');

                ReadCoach.BaseStream.Position = index * BLOCK + 16;
                coachJapaneseName = Encoding.UTF8.GetString(ReadCoach.ReadBytes(0x2d)).TrimEnd('\0');

                ReadCoach.BaseStream.Position = index * BLOCK + 62;
                coachChineseName = Encoding.UTF8.GetString(ReadCoach.ReadBytes(0x2d)).TrimEnd('\0');

                coach = new Coach(coachId);
                coach.Name = coachName;
                coach.ChineseName = coachChineseName;
                coach.JapaneseName = coachJapaneseName;
                coach.Nationality = countryId;
            }
            catch (Exception)
            {
                return null;
            }

            return coach;
        }

        public int LoadCoachById(uint coachId)
        {
            int coachNumber = (int)MemoryCoach.Length / BLOCK;

            ReadCoach.BaseStream.Position = 8;
            for (int i = 0; i < coachNumber; i++)
            {
                if (coachId == ReadCoach.ReadUInt32())
                    return i;

                ReadCoach.BaseStream.Position += BLOCK - 4;
            }

            return -1;
        }

        public int ApplyCoach(int index, Coach coach)
        {
            try
            {
                int offsetBase = BLOCK * index;
                WriteCoach.BaseStream.Position = offsetBase;

                byte zero = 0;

                WriteCoach.Write(coach.Id);

                ReadCoach.BaseStream.Position = index * BLOCK + 8;
                ushort aux1 = ReadCoach.ReadUInt16();
                aux1 = (ushort)(aux1 >> 9);
                aux1 = (ushort)(aux1 << 9);
                aux1 = (ushort)(aux1 | coach.Nationality);
                WriteCoach.BaseStream.Position = offsetBase + 8;
                WriteCoach.Write(aux1);

                WriteCoach.BaseStream.Position = offsetBase + 0x6c;
                for (int i = 0; i <= 33; i++)
                {
                    WriteCoach.Write(zero);
                }
                WriteCoach.BaseStream.Position = offsetBase + 0x6c;
                WriteCoach.Write(coach.Name.ToCharArray());

                WriteCoach.BaseStream.Position = offsetBase + 16;
                for (int i = 0; i <= 45; i++)
                {
                    WriteCoach.Write(zero);
                }
                WriteCoach.BaseStream.Position = offsetBase + 16;
                WriteCoach.Write(coach.JapaneseName.ToCharArray());

                WriteCoach.BaseStream.Position = offsetBase + 62;
                for (int i = 0; i <= 45; i++)
                {
                    WriteCoach.Write(zero);
                }
                WriteCoach.BaseStream.Position = offsetBase + 62;
                WriteCoach.Write(coach.ChineseName.ToCharArray());
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
                byte[] ss13 = Zlib.ZlibFilePC(MemoryCoach.ToArray());
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
            if (MemoryCoach != null)
            {
                MemoryCoach.Close();
                ReadCoach.Close();
                WriteCoach.Close();
                CoachTable.Rows.Clear();
            }
        }

    }
}
