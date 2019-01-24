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
using Microsoft.EntityFrameworkCore;

namespace Uotb.Application.Lecturers.Commands
{
    public class CreateLecturer
    {
        public class Command : ICommand
        {
            public LecturerDto lecturer;
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
                Person person = _mapper.Map<Person>(command.lecturer);
                Employee employee = _mapper.Map<Employee>(command.lecturer);
                Lecturer lecturer = _mapper.Map<Lecturer>(command.lecturer);

                lecturer.Employee = employee;
                employee.Person = person;

                Faculty faculty = await _context.Faculties.FirstOrDefaultAsync(x => x.Name == command.lecturer.FacultyName);

                employee.Faculty = faculty;

                await _context.Lecturers.AddAsync(lecturer);

                await _context.SaveChangesAsync();
            }
        }
    }
}
