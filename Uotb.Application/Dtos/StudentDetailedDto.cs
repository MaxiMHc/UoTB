using System;
using System.Collections.Generic;
using System.Text;
using Uotb.Data.Entities;

namespace Uotb.Application.Dtos
{
    class StudentDetailedDto
    {
        public int Id { get; set; }
        public int IndexNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<FacultyDto> Faculties { get; set; }
        // public List<Mark> Marks { get; set; }
        public List<ClassDto> Classes { get; set; }
    }
}
