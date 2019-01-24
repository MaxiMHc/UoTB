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

namespace Uotb.Application.Staff.Commands
{
    public class CreateStaff
    {
        public class Command : ICommand
        {
            public StaffDto staff;
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
                Person person = _mapper.Map<Person>(command.staff);
                Employee employee = _mapper.Map<Employee>(command.staff);
                Data.Entities.Staff staff = _mapper.Map<Data.Entities.Staff>(command.staff);

                staff.Employee = employee;
                employee.Person = person;

                Faculty faculty = await _context.Faculties.FirstOrDefaultAsync(x => x.Name == command.staff.FacultyName);

                employee.Faculty = faculty;

                await _context.Staff.AddAsync(staff);

                await _context.SaveChangesAsync();
            }
        }
    }
}
