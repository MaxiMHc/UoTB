using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uotb.Application.Dtos;
using Uotb.Application.Semesters.Commands;
using Uotb.Application.Semesters.Queries;
using Uotb.Data.Entities;
using Uotb.Interfaces.CQRS;

namespace Uotb.Api.Controllers
{
    [Route("api/")]
    public class SemestersController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public SemestersController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("semesters")]
        public async Task<List<SemesterDto>> GetAllStudents()
        {
            return await _queryDispatcher.Dispatch<GetAllSemesters.Query, List<SemesterDto>>(new GetAllSemesters.Query());
        }

        //[HttpGet("semester/{id}")]
        //public async Task<Student> GetStudent(int id)
        //{
            
        //}

        [HttpPost("semester")]
        public async Task Create([FromBody] SemesterDto semester)
        {
            await _commandDispatcher.Dispatch<CreateSemester.Command>(new CreateSemester.Command()
            {
                semester = semester
            });
        }
    }
}
