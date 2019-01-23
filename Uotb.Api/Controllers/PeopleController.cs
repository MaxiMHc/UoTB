using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Uotb.Data.Data;
using Uotb.Data.Entities;
using Uotb.Interfaces.CQRS;
using Uotb.Application.People.Commands;
using AutoMapper;
using Uotb.Application.People.Queries;
using Uotb.Application.Dtos;

namespace Uotb.Api.Controllers
{
    [Route("api/")]
    public class PeopleController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public PeopleController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet("person/{id}")]
        public async Task<PersonDto> Get(int id)
        {
            return await _queryDispatcher.Dispatch<GetPerson.Query, PersonDto>(new GetPerson.Query
            {
                Id = id
            });
        }

        [HttpGet("person/all")]
        public async Task<List<PersonDto>> GetAll()
        {
            return await _queryDispatcher.Dispatch<GetAllPeople.Query, List<PersonDto>>(new GetAllPeople.Query());
        }

        [HttpPost("person")]
        public async Task Create([FromBody] PersonDto person)
        {
            await _commandDispatcher.Dispatch<CreatePerson.Command>(new CreatePerson.Command()
            {
                person = person
            });
        }
    }
}
