using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoTool.Models
{
    public class Coach
    {
        public Coach(UInt32 id)
        {
            this.Id = id;
        }

        public UInt32 Id { get; set; }
        public string Name { get; set; }
        public string ChineseName { get; set; }
        public string JapaneseName { get; set; }
        public UInt16 Nationality { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
