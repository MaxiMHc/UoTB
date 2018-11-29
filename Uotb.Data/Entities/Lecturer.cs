using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Data.Entities
{
    public class Lecturer : BaseEntity<int>
    {
        public string Degree { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
