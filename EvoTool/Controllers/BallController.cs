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
    class BallController
    {
        private static readonly string FILE_NAME = "/Ball.bin";
        private static readonly int BLOCK = 140;

        public BallController()
        {
            BallTable = new DataTable();
            BallTable.Columns.Add("Index", typeof(int));
            BallTable.Columns.Add("Name", typeof(string));
        }

        public MemoryStream MemoryBall { get; set; }
        public BinaryReader ReadBall { get; set; }
        public BinaryWriter WriteBall { get; set; }
        public DataTable BallTable { get; set; }

        private MemoryStream UnzlibFile(string patch, int bitRecognized)
        {
            MemoryStream memoryBall = null;

            if (bitRecognized == 0)
            {
                byte[] file = File.ReadAllBytes(patch + FILE_NAME);
                byte[] ss1 = Unzlib.UnZlibFilePC(file);
                memoryBall = new MemoryStream(ss1);
            }
            else if (bitRecognized == 1 || bitRecognized == 2)
            {
                // console file
            }

            return memoryBall;
        }

        public int Load(string patch, int bitRecognized)
        {
            MemoryBall = UnzlibFile(patch, bitRecognized);

            int ballNumber = (int)MemoryBall.Length / BLOCK;

            if (ballNumber == 0)
                return 0;

            string ballName;
            try
            {
                ReadBall = new BinaryReader(MemoryBall);
                long START = -136; // ball name offset

                for (int i = 0; i < ballNumber; i++)
                {
                    START += BLOCK;
                    MemoryBall.Seek(START, SeekOrigin.Begin);
                    ballName = Encoding.UTF8.GetString(ReadBall.ReadBytes(135)).TrimEnd('\0');

                    BallTable.Rows.Add(i, ballName);
                }
                WriteBall = new BinaryWriter(MemoryBall);
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public Ball LoadBall(int index)
        {
            Ball ball;

            UInt16 ballId;
            byte order;
            string ballName;
            try
            {
                ReadBall.BaseStream.Position = index * BLOCK + 4;
                ballName = Encoding.UTF8.GetString(ReadBall.ReadBytes(135)).TrimEnd('\0');

                ReadBall.BaseStream.Position = index * BLOCK;
                ballId = ReadBall.ReadUInt16();

                ReadBall.BaseStream.Position = index * BLOCK + 2;
                order = ReadBall.ReadByte();

                ball = new Ball(ballId);
                ball.Name = ballName;
                ball.Order = order;
            }
            catch (Exception)
            {
                return null;
            }

            return ball;
        }

        public int LoadBallById(UInt16 ballId)
        {
            int ballNumber = (int)MemoryBall.Length / BLOCK;

            ReadBall.BaseStream.Position = 0;
            for (int i = 0; i < ballNumber; i++)
            {
                if (ballId == ReadBall.ReadUInt16())
                    return 1;

                ReadBall.BaseStream.Position += BLOCK - 2;
            }

            return 0;
        }

        public int ApplyBall(int index, Ball ball)
        {
            try
            {
                int offsetBase = BLOCK * index;
                WriteBall.BaseStream.Position = offsetBase;
                byte zero = 0;

                UInt16 id = ball.Id;
                byte order = ball.Order;
                string ballName = ball.Name;
                WriteBall.Write(id);
                WriteBall.Write(order);
                for (int i = 0; i <= 135; i++)
                {
                    WriteBall.Write(zero);
                }

                WriteBall.BaseStream.Position = offsetBase + 4;
                WriteBall.Write(ballName.ToCharArray());
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public int Save(string patch, int bitRecognized)
        {
            try
            {
                if (bitRecognized == 0)
                {
                    byte[] ss13 = Zlib.ZlibFilePC(MemoryBall.ToArray());
                    File.WriteAllBytes(patch + FILE_NAME, ss13);
                }
                else if (bitRecognized == 1)
                {
                    // xbox?
                }
                else if (bitRecognized == 2)
                {
                    // ps3?
                }
            }
            catch (Exception)
            {
                return 1;
            }

            return 0;
        }

        public void CloseMemory()
        {
            if (MemoryBall != null)
            {
                MemoryBall.Close();
                ReadBall.Close();
                WriteBall.Close();
            }
        }

    }
}
