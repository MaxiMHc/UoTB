using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uotb.Application.Dtos;
using Uotb.Application.Lecturers.Commands;
using Uotb.Data.Entities;
using Uotb.Interfaces.CQRS;

namespace Uotb.Api.Controllers
{
    [Route("api/")]
    public class LecturersController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public LecturersController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost("lecturer")]
        public async Task Create([FromBody] LecturerDto lecturer)
        {
            await _commandDispatcher.Dispatch<CreateLecturer.Command>(new CreateLecturer.Command()
            {
                lecturer = lecturer
            });
        }
    }
}
