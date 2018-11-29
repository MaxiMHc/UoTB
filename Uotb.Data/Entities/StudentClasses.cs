using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Data.Entities
{
    public class StudentClasses : BaseEntity<int>
    {
        public virtual Student Student { get; set; }
        public virtual Class Class { get; set; }
    }
}
