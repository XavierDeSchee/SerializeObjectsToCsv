using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeObjectsToCsv
{
    public class Child : Base
    {
        public string StringPropertyChild { get; set; }
        public DateTime DateTimePropertyChild { get; set; }
        public bool BoolPropertyChild { get; set; }
        public Child Brother { get; set; }
    }
}
