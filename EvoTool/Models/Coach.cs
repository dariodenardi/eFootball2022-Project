using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoTool.Models
{
    public class Coach
    {
        public Coach(uint ID)
        {
            this.ID = ID;
        }

        public uint ID { get; set; }
        public string Name { get; set; }
        public string ChineseName { get; set; }
        public string JapaneseName { get; set; }
        public ushort Nationality { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
