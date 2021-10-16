using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvoTool.Models
{
    public class Ball
    {
        public Ball(ushort id)
        {
            this.Id = id;
        }

        public ushort Id { get; set;  }
        public byte Order { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }
}
