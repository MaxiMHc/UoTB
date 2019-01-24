using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uotb.Application.Dtos;
using Uotb.Application.MarkTypes.Commands;
using Uotb.Application.MarkTypes.Queries;
using Uotb.Data.Entities;
using Uotb.Interfaces.CQRS;

namespace Uotb.Api.Controllers
{
    [Route("api/")]
    public class MarkTypesController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public MarkTypesController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("marktypes")]
        public async Task<List<MarkTypeDto>> GetAllStudents()
        {
            return await _queryDispatcher.Dispatch<GetAllMarkTypes.Query, List<MarkTypeDto>>(new GetAllMarkTypes.Query());
        }

        //[HttpGet("semester/{id}")]
        //public async Task<Student> GetStudent(int id)
        //{

        //}

        [HttpPost("marktype")]
        public async Task Create([FromBody] MarkTypeDto markType)
        {
            await _commandDispatcher.Dispatch<CreateMarkType.Command>(new CreateMarkType.Command()
            {
                marktype = markType
            });
        }
    }
}
