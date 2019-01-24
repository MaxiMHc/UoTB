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
    public class GetAllStudentMarks
    {
        public class Query : IQuery
        {
            public int id;
        }

        public class Handler : IQueryHandler<Query, List<MarkDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<MarkDto>> Handle(Query query)
            {
                var s = await _context.Students.FirstOrDefaultAsync(x => x.Id == query.id);
                await _context.Entry(s).Collection(x => x.Marks).LoadAsync();

                var result = new List<MarkDto>();
                foreach (var item in s.Marks)
                {
                    MarkDto mark = new MarkDto();
                    await _context.Entry(item).Reference(x => x.MarkType).LoadAsync();
                    await _context.Entry(item).Reference(x => x.Subject).LoadAsync();
                    _mapper.Map<MarkType, MarkDto>(item.MarkType, mark);
                    _mapper.Map<Mark, MarkDto>(item, mark);
                    mark.SubjectId = item.Subject.Id;
                    mark.SubjectName = item.Subject.Name;

                    result.Add(mark);
                }

                return result;
            }
        }
    }
}
