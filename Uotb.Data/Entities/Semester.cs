using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Data.Entities
{
    public class Semester : BaseEntity<int>
    {
        public int Number { get; set; }
        public string Symbol { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<StudentFaculties> StudentFaculties { get; set; }
    }
}
