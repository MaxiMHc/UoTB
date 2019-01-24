using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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
                Person person = _mapper.Map<Person>(command.student);
                Student student = _mapper.Map<Student>(command.student);
                student.Person = person;
                int index = _context.Students.LastOrDefault()?.IndexNumber + 1 ?? 1;
                student.IndexNumber = index;
                await _context.Students.AddAsync(student);

                await _context.SaveChangesAsync();
            }
        }
    }
}
