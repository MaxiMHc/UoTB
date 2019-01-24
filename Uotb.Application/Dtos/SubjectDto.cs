using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Application.Dtos
{
    public class SubjectDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int SemesterId { get; set; }
        public int Number { get; set; }
        public string Symbol { get; set; }

        public int OwnerId { get; set; }
        public string Degree { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int FacultyId { get; set; }
        public string FacultyName { get; set; }
        public string Abbreviation { get; set; }
    }
}
