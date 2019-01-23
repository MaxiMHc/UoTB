using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Application.Dtos
{
    public class StudentDto
    {
        public int IndexNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
