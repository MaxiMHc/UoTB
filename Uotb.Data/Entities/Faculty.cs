using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Data.Entities
{
    public class Faculty : BaseEntity<int>
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<StudentFaculties> StudentFaculties { get; set; }
    }
}
