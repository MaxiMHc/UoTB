using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Data.Entities
{
    public class MarkType : BaseEntity<int>
    {
        public string Name { get; set; }
        public int Importance { get; set; }
        public virtual ICollection<Mark> Marks { get; set; }
    }
}
