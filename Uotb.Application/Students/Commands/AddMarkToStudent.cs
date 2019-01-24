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
    public class AddMarkToStudent
    {
        public class Command : ICommand
        {
            public int id;
            public MarkDto mark;
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

            // id, value, name, subjectid
            public async Task Execute(Command command)
            {
                Mark mark = _mapper.Map<Mark>(command.mark);

                MarkType marktype = await _context.MarkTypes.FirstOrDefaultAsync(x => x.Name == command.mark.Name);
                mark.MarkType = marktype;

                Subject subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == command.mark.SubjectId);
                mark.Subject = subject;

                Student student = await _context.Students.FirstOrDefaultAsync(x => x.Id == command.id);
                mark.Student = student;

                await _context.Marks.AddAsync(mark);

                await _context.SaveChangesAsync();
            }
        }
    }
}
