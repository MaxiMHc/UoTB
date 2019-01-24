using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Application.Dtos
{
    public class StudentFacultyDto
    {
        // Faculty
        public int FacultyId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        // Semester
        public int SemesterId { get; set; }
        public int Number { get; set; }
        public string Symbol { get; set; }
    }
}
