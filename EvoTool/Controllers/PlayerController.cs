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
    class PlayerController
    {
        private static readonly string FILE_NAME = "/Player.bin";
        private static readonly int BLOCK = 392;

        public PlayerController()
        {
            PlayerTable = new DataTable();
            PlayerTable.Columns.Add("Index", typeof(int));
            PlayerTable.Columns.Add("Name", typeof(string));
        }

        public MemoryStream MemoryPlayer { get; set; }
        public BinaryReader ReadPlayer { get; set; }
        public BinaryWriter WritePlayer { get; set; }
        public DataTable PlayerTable { get; set; }

        private MemoryStream UnzlibFile(string patch)
        {
            MemoryStream memoryBall = null;

            byte[] file = File.ReadAllBytes(patch + FILE_NAME);
            byte[] ss1 = Unzlib.UnZlibFilePC(file);
            memoryBall = new MemoryStream(ss1);

            return memoryBall;
        }

        public int Load(string patch)
        {
            MemoryPlayer = UnzlibFile(patch);

            int playerNumber = (int)MemoryPlayer.Length / BLOCK;

            if (playerNumber == 0)
                return 0;

            string playerName;
            try
            {
                ReadPlayer = new BinaryReader(MemoryPlayer);
                long START = -68; // player name offset

                for (int i = 0; i < playerNumber; i++)
                {
                    START += BLOCK;
                    MemoryPlayer.Seek(START, SeekOrigin.Begin);
                    playerName = Encoding.UTF8.GetString(ReadPlayer.ReadBytes(44)).TrimEnd('\0');

                    PlayerTable.Rows.Add(i, playerName);
                }
                WritePlayer = new BinaryWriter(MemoryPlayer);
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public void CloseMemory()
        {
            if (MemoryPlayer != null)
            {
                MemoryPlayer.Close();
                ReadPlayer.Close();
                WritePlayer.Close();
                PlayerTable.Rows.Clear();
            }
        }
    }
}
