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
    public class GetAllStudents
    {
        public class Query : IQuery
        {

        }

        public class Handler : IQueryHandler<Query, List<StudentDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<StudentDto>> Handle(Query query)
            {
                var students = await _context.Students.ToListAsync();
                List<StudentDto> result = new List<StudentDto>();

                foreach (var item in students)
                {
                    StudentDto s = _mapper.Map<StudentDto>(item);
                    await _context.Entry(item).Reference(x => x.Person).LoadAsync();
                    s.FirstName = item.Person.FirstName;
                    s.LastName = item.Person.LastName;
                    s.DateOfBirth = item.Person.DateOfBirth;
                    result.Add(s);
                }

                return result;
            }
        }
    }
}
