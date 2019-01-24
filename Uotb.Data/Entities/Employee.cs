using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Data.Entities
{
    public class Employee : BaseEntity<int>
    {
        public DateTime EmploymentDate { get; set; }
        public virtual ICollection<Staff> Staff { get; set; }
        public virtual ICollection<Lecturer> Lecturers { get; set; }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public int FacultyId { get; set; }
        public virtual Faculty Faculty { get; set; }
    }
}
