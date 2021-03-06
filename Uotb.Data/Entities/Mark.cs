﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Data.Entities
{
    public class Mark : BaseEntity<int>
    {
        public int Value { get; set; }
        public int MarkTypeId { get; set; }
        public virtual MarkType MarkType { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
