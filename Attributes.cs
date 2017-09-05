using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeObjectsToCsv
{
    public class InternalUseOnly : Attribute
    {
        bool ForInternalUseOnly { get; set; }
        public InternalUseOnly(bool forInternalUseOnly)
        {
            this.ForInternalUseOnly = forInternalUseOnly;
        }
    }
}
