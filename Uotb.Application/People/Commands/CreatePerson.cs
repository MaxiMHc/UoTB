using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uotb.Data.Data;
using Uotb.Interfaces.CQRS;
using Uotb.Data.Entities;

namespace Uotb.Application.People.Commands
{
    public class CreatePerson
    {
        public class Command : ICommand
        {
            public PersonDto person;
        }

        public class Handler : ICommandHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task Execute(Command command)
            {
                await _context.Persons.AddAsync(command.person.ToEntity());

                await _context.SaveChangesAsync();
            }
        }

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
}
