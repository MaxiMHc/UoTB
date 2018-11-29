using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Data.Entities
{
    public class Subject : BaseEntity<int>
    {
        public string Name { get; set; }
        public virtual Semester Semester { get; set; }
        public virtual Lecturer Owner { get; set; }
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
