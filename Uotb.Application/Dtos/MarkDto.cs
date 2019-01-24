using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Application.Dtos
{
    public class MarkDto
    {
        public int Value { get; set; }
        public int MarkTypeId { get; set; }
        public int SubjectId { get; set; }
        public int StudentId { get; set; }
    }
}
