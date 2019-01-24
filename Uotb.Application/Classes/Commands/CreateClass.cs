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

namespace Uotb.Application.Classes.Commands
{
    public class CreateClass
    {
        public class Command : ICommand
        {
            public ClassDto classdto;
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

            // name, 2 ids
            public async Task Execute(Command command)
            {
                Class c = _mapper.Map<Class>(command.classdto);
                Lecturer lecturer = await _context.Lecturers.FirstOrDefaultAsync(x => x.Id == command.classdto.LecturerId);
                Subject subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == command.classdto.SubjectId);

                c.Subject = subject;
                c.Lecturer = lecturer;

                await _context.Classes.AddAsync(c);

                await _context.SaveChangesAsync();
            }
        }
    }
}
