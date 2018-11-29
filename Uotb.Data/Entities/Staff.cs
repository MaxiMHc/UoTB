using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Data.Entities
{
    public class Staff : BaseEntity<int>
    {
        public string Role { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
