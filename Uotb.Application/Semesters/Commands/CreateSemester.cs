using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uotb.Application.Dtos;
using Uotb.Data.Data;
using Uotb.Data.Entities;
using Uotb.Interfaces.CQRS;

namespace Uotb.Application.Semesters.Commands
{
    public class CreateSemester
    {
        public class Command : ICommand
        {
            public SemesterDto semester;
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
                await _context.Semesters.AddAsync(_mapper.Map<Semester>(command.semester));
                await _context.SaveChangesAsync();
            }
        }
    }
}
