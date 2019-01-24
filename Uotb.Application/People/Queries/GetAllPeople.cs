using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uotb.Application.Dtos;
using Uotb.Data.Data;
using Uotb.Interfaces.CQRS;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Uotb.Application.People.Queries
{
    public class GetAllPeople
    {
        public class Query : IQuery
        {
            
        }

        public class Handler : IQueryHandler<Query, List<PersonDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<PersonDto>> Handle(Query query)
            {
                var xd = await _context.Persons.ToListAsync();
                var pog = _mapper.Map<List<PersonDto>>(xd);

                return pog;
            }
        }
    }
}
