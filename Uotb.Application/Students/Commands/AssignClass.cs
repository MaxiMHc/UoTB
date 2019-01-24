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

namespace Uotb.Application.Students.Commands
{
    public class AssignClass
    {
        public class Command : ICommand
        {
            public int id;
            public int classId;
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

            // student id, class id
            public async Task Execute(Command command)
            {
                StudentClasses studentClasses = new StudentClasses();
                Student student = await _context.Students.FirstOrDefaultAsync(x => x.Id == command.id);
                Class c = await _context.Classes.FirstOrDefaultAsync(x => x.Id == command.classId);

                studentClasses.Student = student;
                studentClasses.Class = c;

                await _context.StudentClasses.AddAsync(studentClasses);

                await _context.SaveChangesAsync();
            }
        }
    }
}
