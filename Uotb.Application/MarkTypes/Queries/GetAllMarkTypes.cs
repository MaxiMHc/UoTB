using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uotb.Application.Dtos;
using Uotb.Data.Data;
using Uotb.Interfaces.CQRS;

namespace Uotb.Application.MarkTypes.Queries
{
    public class GetAllMarkTypes
    {
        public class Query : IQuery
        {

        }

        public class Handler : IQueryHandler<Query, List<MarkTypeDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<MarkTypeDto>> Handle(Query query)
            {
                var sems = await _context.MarkTypes.ToListAsync();

                return _mapper.Map<List<MarkTypeDto>>(sems);
            }
        }
    }
}
