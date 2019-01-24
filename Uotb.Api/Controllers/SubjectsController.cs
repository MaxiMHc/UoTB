using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uotb.Application.Dtos;
using Uotb.Application.Subjects.Commands;
using Uotb.Application.Subjects.Queries;
using Uotb.Data.Entities;
using Uotb.Interfaces.CQRS;

namespace Uotb.Api.Controllers
{
    [Route("api/")]
    public class SubjectsController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public SubjectsController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("subjects")]
        public async Task<List<SubjectDto>> GetAll()
        {
            return await _queryDispatcher.Dispatch<GetAllSubjects.Query, List<SubjectDto>>(new GetAllSubjects.Query());
        }

        [HttpPost("subject")]
        public async Task Create([FromBody] SubjectDto subject)
        {
            await _commandDispatcher.Dispatch<CreateSubject.Command>(new CreateSubject.Command()
            {
                subject = subject
            });
        }
    }
}
