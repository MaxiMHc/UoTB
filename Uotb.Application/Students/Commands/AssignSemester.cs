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

namespace Uotb.Application.Students.Commands
{
    public class AssignSemester
    {
        public class Command : ICommand
        {
            public int id;
            public int facultyId;
            public int semestrId;
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

            // student id, 2 ids
            public async Task Execute(Command command)
            {
                StudentFaculties studentFaculties = new StudentFaculties();
                Student student = await _context.Students.FirstOrDefaultAsync(x => x.Id == command.id);
                Faculty faculty = await _context.Faculties.FirstOrDefaultAsync(x => x.Id == command.facultyId);
                Semester semester = await _context.Semesters.FirstOrDefaultAsync(x => x.Id == command.semestrId);

                studentFaculties.Student = student;
                studentFaculties.Faculty = faculty;
                studentFaculties.Semester = semester;

                await _context.StudentFaculties.AddAsync(studentFaculties);

                await _context.SaveChangesAsync();
            }
        }
    }
}
