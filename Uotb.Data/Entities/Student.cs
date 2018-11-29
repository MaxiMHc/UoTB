using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Data.Entities
{
    public class Student : BaseEntity<int>
    {
        public virtual Person Person { get; set; }
        public int IndexNumber { get; set; }
        public virtual ICollection<StudentClasses> StudentClasses { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual ICollection<StudentFaculties> StudentFaculties { get; set; }
    }
}
