using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Application.Dtos
{
    public class ClassDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }

        public int LecturerId { get; set; }
        public string Degree { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
