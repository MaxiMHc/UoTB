using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Data.Entities
{
    public class Class : BaseEntity<int>
    {
        public string Name { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public int LecturerId { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public virtual ICollection<StudentClasses> StudentClasses { get; set; }
    }
}
