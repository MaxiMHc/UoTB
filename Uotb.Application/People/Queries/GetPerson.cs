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
    public class GetPerson
    {
        public class Query : IQuery
        {
            public int Id;
        }

        public class Handler : IQueryHandler<Query, PersonDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PersonDto> Handle(Query query)
            {
                var xd = await _context.Persons.FirstOrDefaultAsync(x => x.Id == query.Id);

                return _mapper.Map<PersonDto>(xd);
            }
        }
    }
}
