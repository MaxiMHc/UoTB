using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Data.Entities
{
    public class StudentFaculties : BaseEntity<int>
    {
        public virtual Student Student { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual Semester Semester { get; set; }
    }
}
