using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Uotb.Application.Dtos;
using Uotb.Application.Staff.Commands;
using Uotb.Application.Staff.Queries;
using Uotb.Data.Entities;
using Uotb.Interfaces.CQRS;

namespace Uotb.Api.Controllers
{
    [Route("api/")]
    public class StaffController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public StaffController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("staff")]
        public async Task<List<StaffDto>> GetAll()
        {
            return await _queryDispatcher.Dispatch<GetAllStaff.Query, List<StaffDto>>(new GetAllStaff.Query());
        }

        [HttpPost("staff")]
        public async Task Create([FromBody] StaffDto staff)
        {
            await _commandDispatcher.Dispatch<CreateStaff.Command>(new CreateStaff.Command()
            {
                staff = staff
            });
        }
    }
}
