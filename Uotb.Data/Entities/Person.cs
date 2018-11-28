using System;
using System.Collections.Generic;
using System.Text;

namespace Uotb.Data.Entities
{
    public class Person : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
