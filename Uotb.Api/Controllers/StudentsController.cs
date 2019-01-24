using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uotb.Application.Dtos;
using Uotb.Application.Students.Commands;
using Uotb.Application.Students.Queries;
using Uotb.Data.Entities;
using Uotb.Interfaces.CQRS;

namespace Uotb.Api.Controllers
{
    [Route("api/")]
    public class StudentsController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public StudentsController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("students")]
        public async Task<List<StudentDto>> GetAllStudents()
        {
            return await _queryDispatcher.Dispatch<GetAllStudents.Query, List<StudentDto>>(new GetAllStudents.Query());
        }

        [HttpGet("student/{id}")]
        public async Task<Student> GetStudent(int id)
        {
            return await _queryDispatcher.Dispatch<GetStudent.Query, Student>(new GetStudent.Query
            {
                id = id
            });
        }

        [HttpPost("student")]
        public async Task Create([FromBody] StudentDto student)
        {
            await _commandDispatcher.Dispatch<CreateStudent.Command>(new CreateStudent.Command()
            {
                student = student
            });
        }
    }
}
