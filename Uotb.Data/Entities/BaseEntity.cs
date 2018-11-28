using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Data.Entities
{
    public class BaseEntity<Tkey>
    {
        public Tkey Id { get; set; }
    }
}
