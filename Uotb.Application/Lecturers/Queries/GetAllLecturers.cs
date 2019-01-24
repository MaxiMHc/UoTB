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

namespace Uotb.Application.Lecturers.Queries
{
    public class GetAllLecturers
    {
        public class Query : IQuery
        {

        }

        public class Handler : IQueryHandler<Query, List<LecturerDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<LecturerDto>> Handle(Query query)
            {
                var lecturers = await _context.Lecturers.ToListAsync();
                List<LecturerDto> result = new List<LecturerDto>();

                foreach (var item in lecturers)
                {
                    LecturerDto s = _mapper.Map<LecturerDto>(item);
                    await _context.Entry(item).Reference(x => x.Employee).LoadAsync();
                    await _context.Entry(item.Employee).Reference(x => x.Person).LoadAsync();
                    await _context.Entry(item.Employee).Reference(x => x.Faculty).LoadAsync();

                    _mapper.Map<Employee, LecturerDto>(item.Employee, s);
                    _mapper.Map<Person, LecturerDto>(item.Employee.Person, s);
                    s.FacultyName = item.Employee.Faculty.Name;

                    result.Add(s);
                }

                return result;
            }
        }
    }
}
