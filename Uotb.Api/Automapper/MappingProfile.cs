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

            CreateMap<MarkType, MarkDto>();
            CreateMap<Mark, MarkDto>();
            CreateMap<MarkDto, Mark>();

            CreateMap<Faculty, FacultyDto>();
            CreateMap<FacultyDto, Faculty>();

            CreateMap<Lecturer, LecturerDto>();
            CreateMap<LecturerDto, Lecturer>();
            CreateMap<LecturerDto, Person>();
            CreateMap<LecturerDto, Employee>();
            CreateMap<Person, LecturerDto>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Employee, LecturerDto>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Subject, SubjectDto>();
            CreateMap<SubjectDto, Subject>();
            CreateMap<Semester, SubjectDto>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Person, SubjectDto>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Faculty, SubjectDto>().ForMember(x => x.Name, opt => opt.Ignore()).ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Class, ClassDto>();
            CreateMap<ClassDto, Class>();
            CreateMap<Person, ClassDto>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Semester, StudentFacultyDto>();
            CreateMap<Faculty, StudentFacultyDto>();

            CreateMap<Staff, StaffDto>();
            CreateMap<StaffDto, Staff>();
            CreateMap<Person, StaffDto>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Employee, StaffDto>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<StaffDto, Person>();
            CreateMap<StaffDto, Employee>();
        }
    }
}
