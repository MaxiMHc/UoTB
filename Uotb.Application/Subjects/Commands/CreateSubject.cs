using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Uotb.Application.Dtos;
using Uotb.Data.Data;
using Uotb.Data.Entities;
using Uotb.Interfaces.CQRS;
using Microsoft.EntityFrameworkCore;

namespace Uotb.Application.Subjects.Commands
{
    public class CreateSubject
    {
        public class Command : ICommand
        {
            public SubjectDto subject;
        }

        public class Handler : ICommandHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task Execute(Command command)
            {
                Subject subject = _mapper.Map<Subject>(command.subject);

                Lecturer lecturer = await _context.Lecturers.FirstOrDefaultAsync(x => x.Id == command.subject.OwnerId);
                Faculty faculty = await _context.Faculties.FirstOrDefaultAsync(x => x.Id == command.subject.FacultyId);
                Semester semester = await _context.Semesters.FirstOrDefaultAsync(x => x.Id == command.subject.SemesterId);

                subject.Semester = semester;
                subject.Faculty = faculty;
                subject.Owner = lecturer;

                await _context.Subjects.AddAsync(subject);

                await _context.SaveChangesAsync();
            }
        }
    }
}
