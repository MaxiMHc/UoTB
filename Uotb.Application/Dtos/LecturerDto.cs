using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Application.Dtos
{
    public class LecturerDto
    {
        public int Id { get; set; }

        public string Degree { get; set; }

        public DateTime EmploymentDate { get; set; }

        public int FacultyId { get; set; }
        public string FacultyName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
