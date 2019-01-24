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
    public class GetAllStudentClasses
    {
        public class Query : IQuery
        {
            public int id;
        }

        public class Handler : IQueryHandler<Query, List<ClassDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ClassDto>> Handle(Query query)
            {
                var s = await _context.Students.FirstOrDefaultAsync(x => x.Id == query.id);
                await _context.Entry(s).Collection(x => x.StudentClasses).LoadAsync();

                var result = new List<ClassDto>();
                foreach (var item in s.StudentClasses)
                {
                    Class c = await _context.Classes.FirstOrDefaultAsync(x => x.Id == item.ClassId);
                    await _context.Entry(c).Reference(x => x.Lecturer).LoadAsync();
                    await _context.Entry(c).Reference(x => x.Subject).LoadAsync();

                    await _context.Entry(c.Lecturer).Reference(x => x.Employee).LoadAsync();
                    await _context.Entry(c.Lecturer.Employee).Reference(x => x.Person).LoadAsync();

                    ClassDto classDto = _mapper.Map<ClassDto>(c);
                    _mapper.Map<Person, ClassDto>(c.Lecturer.Employee.Person, classDto);
                    classDto.Degree = c.Lecturer.Degree;
                    classDto.LecturerId = c.Lecturer.Id;

                    classDto.SubjectName = c.Subject.Name;
                    classDto.SubjectId = c.Subject.Id;

                    result.Add(classDto);
                }

                return result;
            }
        }
    }
}
