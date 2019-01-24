using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Data.Entities
{
    public class StudentClasses : BaseEntity<int>
    {
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
