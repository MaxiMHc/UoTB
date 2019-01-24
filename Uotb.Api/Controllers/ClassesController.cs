using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uotb.Application.Dtos;
using Uotb.Application.Classes.Commands;
using Uotb.Application.Classes.Queries;
using Uotb.Data.Entities;
using Uotb.Interfaces.CQRS;

namespace Uotb.Api.Controllers
{
    [Route("api/")]
    public class ClassesController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public ClassesController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("classes")]
        public async Task<List<ClassDto>> GetAll()
        {
            return await _queryDispatcher.Dispatch<GetAllClasses.Query, List<ClassDto>>(new GetAllClasses.Query());
        }
        
        // name, 2 ids
        [HttpPost("class")]
        public async Task Create([FromBody] ClassDto classDto)
        {
            await _commandDispatcher.Dispatch<CreateClass.Command>(new CreateClass.Command()
            {
                classdto = classDto
            });
        }
    }
}
