using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uotb.Application.Dtos;
using Uotb.Data.Data;
using Uotb.Data.Entities;
using Uotb.Interfaces.CQRS;

namespace Uotb.Application.Students.Commands
{
    public class CreateStudent
    {
        public class Command : ICommand
        {
            public StudentDto student;
        }

        public class Handler : ICommandHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task Execute(Command command)
            {
                await _context.Persons.AddAsync(_mapper.Map<Person>(command.student));

                command.student = command.student;

                await _context.SaveChangesAsync();
            }
        }
    }
}
