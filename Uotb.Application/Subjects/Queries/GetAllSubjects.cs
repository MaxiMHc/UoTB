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

namespace Uotb.Application.Subjects.Queries
{
    public class GetAllSubjects
    {
        public class Query : IQuery
        {

        }

        public class Handler : IQueryHandler<Query, List<SubjectDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<SubjectDto>> Handle(Query query)
            {
                var subjects = await _context.Subjects.ToListAsync();
                List<SubjectDto> result = new List<SubjectDto>();

                foreach (var item in subjects)
                {
                    SubjectDto s = _mapper.Map<SubjectDto>(item);
                    await _context.Entry(item).Reference(x => x.Faculty).LoadAsync();
                    await _context.Entry(item).Reference(x => x.Semester).LoadAsync();

                    await _context.Entry(item).Reference(x => x.Owner).LoadAsync();
                    await _context.Entry(item.Owner).Reference(x => x.Employee).LoadAsync();
                    await _context.Entry(item.Owner.Employee).Reference(x => x.Person).LoadAsync();

                    _mapper.Map<Semester, SubjectDto>(item.Semester, s);
                    s.SemesterId = item.Semester.Id;
                    _mapper.Map<Faculty, SubjectDto>(item.Faculty, s);
                    s.FacultyId = item.Faculty.Id;
                    _mapper.Map<Person, SubjectDto>(item.Owner.Employee.Person, s);
                    s.OwnerId = item.Owner.Id;
                    s.Degree = item.Owner.Degree;

                    s.FacultyName = item.Faculty.Name;

                    result.Add(s);
                }

                return result;
            }
        }
    }
}
