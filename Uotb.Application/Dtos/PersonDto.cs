using System;
using System.Collections.Generic;
using System.Text;
using Uotb.Data.Entities;

namespace Uotb.Application.Dtos
{
    public class PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Person ToEntity()
        {
            return new Person
            {
                DateOfBirth = DateOfBirth,
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}
