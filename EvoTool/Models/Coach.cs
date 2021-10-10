using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoTool.Models
{
    public class Coach
    {
        public Coach(UInt16 id)
        {
            this.Id = id;
        }

        public UInt16 Id { get; set; }
        public string Name { get; set; }
        public string JapaneseName { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
