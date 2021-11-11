using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoTool.Models
{
    public class Boot
    {
        public Boot(ushort ID)
        {
            this.ID = ID;
        }

        public ushort ID { get; set; }
        public byte Order { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
