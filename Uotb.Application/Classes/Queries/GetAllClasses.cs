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

namespace Uotb.Application.Classes.Queries
{
    public class GetAllClasses
    {
        public class Query : IQuery
        {

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
                var classes = await _context.Classes.ToListAsync();
                List<ClassDto> result = new List<ClassDto>();

                foreach (var item in classes)
                {
                    ClassDto c = _mapper.Map<ClassDto>(item);
                    await _context.Entry(item).Reference(x => x.Subject).LoadAsync();
                    await _context.Entry(item).Reference(x => x.Lecturer).LoadAsync();
                    await _context.Entry(item.Lecturer).Reference(x => x.Employee).LoadAsync();
                    await _context.Entry(item.Lecturer.Employee).Reference(x => x.Person).LoadAsync();

                    c.SubjectId = item.SubjectId;
                    c.SubjectName = item.Subject.Name;
                    c.Degree = item.Lecturer.Degree;
                    c.LecturerId = item.Lecturer.Id;
                    _mapper.Map<Person, ClassDto>(item.Lecturer.Employee.Person, c);

                    result.Add(c);
                }

                return result;
            }
        }
    }
}
