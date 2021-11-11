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
    public class TeamController
    {
        private static readonly string FILE_NAME = "/Team.bin";
        private static readonly int BLOCK = 1520;

        public TeamController()
        {
            TeamTable = new DataTable();
            TeamTable.Columns.Add("Index", typeof(int));
            TeamTable.Columns.Add("Name", typeof(string));
        }

        private MemoryStream MemoryTeam { get; set; }
        private BinaryReader ReadTeam { get; set; }
        private BinaryWriter WriteTeam { get; set; }
        public DataTable TeamTable { get; set; }

        private MemoryStream UnzlibFile(string patch)
        {
            MemoryStream memoryTeam = null;

            byte[] file = File.ReadAllBytes(patch + FILE_NAME);
            byte[] ss1 = Unzlib.UnZlibFilePC(file);
            memoryTeam = new MemoryStream(ss1);

            return memoryTeam;
        }

        public int Load(string patch)
        {
            MemoryTeam = UnzlibFile(patch);

            int teamNumber = (int)MemoryTeam.Length / BLOCK;

            if (teamNumber == 0)
                return 0;

            string teamEnglishName;
            try
            {
                ReadTeam = new BinaryReader(MemoryTeam);
                long START = -1144; // team name offset

                for (int i = 0; i < teamNumber; i++)
                {
                    START += BLOCK;
                    MemoryTeam.Seek(START, SeekOrigin.Begin);
                    teamEnglishName = Encoding.UTF8.GetString(ReadTeam.ReadBytes(50)).TrimEnd('\0');

                    TeamTable.Rows.Add(i, teamEnglishName);
                }
                WriteTeam = new BinaryWriter(MemoryTeam);
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public void CloseMemory()
        {
            if (MemoryTeam != null)
            {
                MemoryTeam.Close();
                ReadTeam.Close();
                WriteTeam.Close();
                TeamTable.Rows.Clear();
            }
        }

    }
}
