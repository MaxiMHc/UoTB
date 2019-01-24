using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Data.Entities
{
    public class StudentFaculties : BaseEntity<int>
    {
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
        public int SemesterId { get; set; }
        public virtual Semester Semester { get; set; }
    }
}
