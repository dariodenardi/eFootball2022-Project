using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoTool.Models
{
    public class Stadium
    {

        public Stadium(UInt16 id)
        {
            this.Id = id;
        }

        public UInt16 Id { get; set; }
        public string Name { get; set; }
        public string JapaneseName { get; set; }
        public UInt16 Country { get; set; }
        public UInt16 Capacity { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
