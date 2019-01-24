using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uotb.Application.Dtos;
using Uotb.Data.Data;
using Uotb.Data.Entities;
using Uotb.Interfaces.CQRS;

namespace Uotb.Application.Students.Queries
{
    public class GetStudent
    {
        public class Query : IQuery
        {
            public int id;
        }

        public class Handler : IQueryHandler<Query, Student>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Student> Handle(Query query)
            {
                var s = await _context.Students.FirstOrDefaultAsync(x => x.Id == query.id);
                await _context.Entry(s).Reference(x => x.Person).LoadAsync();
                await _context.Entry(s).Collection(x => x.StudentClasses).LoadAsync();
                await _context.Entry(s).Collection(x => x.StudentFaculties).LoadAsync();

                

                return s;
            }
        }
    }
}
