using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoTool.Models
{
    class Country
    {
        public Country(UInt16 id)
        {
            this.Id = id;
        }

        public UInt16 Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
