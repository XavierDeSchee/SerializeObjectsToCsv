using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeObjectsToCsv
{
    public class Base
    {
        public string StringPropertyBase { get; set; }
        public double DoublePropertyBase { get; set; }
        [InternalUseOnly(true)]
        public bool BoolPropertyBase { get; set; }
    }
}
