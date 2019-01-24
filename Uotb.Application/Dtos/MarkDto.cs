using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Application.Dtos
{
    public class MarkDto
    {
        public int Value { get; set; }

        public string Name { get; set; }
        public int Importance { get; set; }

        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}
