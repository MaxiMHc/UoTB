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
    public class GetAllStudentSemesters
    {
        public class Query : IQuery
        {
            public int id;
        }

        public class Handler : IQueryHandler<Query, List<StudentFacultyDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<StudentFacultyDto>> Handle(Query query)
            {
                var s = await _context.Students.FirstOrDefaultAsync(x => x.Id == query.id);
                await _context.Entry(s).Collection(x => x.StudentFaculties).LoadAsync();

                var result = new List<StudentFacultyDto>();
                foreach (var item in s.StudentFaculties)
                {
                    await _context.Entry(item).Reference(x => x.Semester).LoadAsync();
                    await _context.Entry(item).Reference(x => x.Faculty).LoadAsync();

                    StudentFacultyDto sf = new StudentFacultyDto();
                    _mapper.Map<Semester, StudentFacultyDto>(item.Semester, sf);
                    _mapper.Map<Faculty, StudentFacultyDto>(item.Faculty, sf);
                    sf.FacultyId = item.Faculty.Id;
                    sf.SemesterId = item.Semester.Id;

                    result.Add(sf);
                }

                return result;
            }
        }
    }
}
