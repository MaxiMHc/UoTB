using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uotb.Application.Dtos;
using Uotb.Data.Data;
using Uotb.Interfaces.CQRS;
using Uotb.Data.Entities;

namespace Uotb.Application.MarkTypes.Commands
{
    public class CreateMarkType
    {
        public class Command : ICommand
        {
            public MarkTypeDto marktype;
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
                await _context.MarkTypes.AddAsync(_mapper.Map<MarkType>(command.marktype));
                await _context.SaveChangesAsync();
            }
        }
    }
}
