using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Uotb.Application.Dtos;
using Uotb.Data.Data;
using Uotb.Interfaces.CQRS;

namespace Uotb.Application.Faculties.Queries
{
    public class GetAllFaculties
    {
        public class Query : IQuery
        {

        }

        public class Handler : IQueryHandler<Query, List<FacultyDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<FacultyDto>> Handle(Query query)
            {
                var fac = await _context.Faculties.ToListAsync();

                return _mapper.Map<List<FacultyDto>>(fac);
            }
        }
    }
}
