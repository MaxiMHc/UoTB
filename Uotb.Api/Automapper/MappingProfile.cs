using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uotb.Application.Dtos;
using Uotb.Data.Entities;

namespace Uotb.Api.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile ()
        {
            this.IgnoreUnmapped();
            CreateMap<Person, PersonDto>();
            CreateMap<PersonDto, Person>();

            CreateMap<StudentDto, Person>();
            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentDto>();

            CreateMap<Semester, SemesterDto>();
            CreateMap<SemesterDto, Semester>();

            CreateMap<MarkType, MarkTypeDto>();
            CreateMap<MarkTypeDto, MarkType>();

            CreateMap<Faculty, FacultyDto>();
            CreateMap<FacultyDto, Faculty>();

            CreateMap<Lecturer, LecturerDto>();
            CreateMap<LecturerDto, Lecturer>();
            CreateMap<LecturerDto, Person>();
            CreateMap<LecturerDto, Employee>();
        }
    }
}
