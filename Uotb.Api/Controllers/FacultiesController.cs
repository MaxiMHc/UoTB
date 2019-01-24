using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uotb.Application.Dtos;
using Uotb.Application.Faculties.Commands;
using Uotb.Application.Faculties.Queries;
using Uotb.Data.Entities;
using Uotb.Interfaces.CQRS;

namespace Uotb.Api.Controllers
{
    [Route("api/")]
    public class FacultiesController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public FacultiesController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("faculties")]
        public async Task<List<FacultyDto>> GetAllStudents()
        {
            return await _queryDispatcher.Dispatch<GetAllFaculties.Query, List<FacultyDto>>(new GetAllFaculties.Query());
        }

        //[HttpGet("semester/{id}")]
        //public async Task<Student> GetStudent(int id)
        //{

        //}

        [HttpPost("faculty")]
        public async Task Create([FromBody] FacultyDto faculty)
        {
            await _commandDispatcher.Dispatch<CreateFaculty.Command>(new CreateFaculty.Command()
            {
                facultyDto = faculty
            });
        }
    }
}
