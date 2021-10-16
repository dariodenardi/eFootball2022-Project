using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvoTool.Models
{

    public class Boot
    {
        public Boot(ushort id)
        {
            this.Id = id;
        }

        public ushort Id { get; set; }
        public byte Order { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
