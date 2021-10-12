using KdsOnline.Application.Features.PersonalDetails;
using KdsOnline.Application.Features.PersonalDetails.Commands;
using KdsOnline.Application.Features.PersonalDetails.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KdsOnline.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class PersonalDetailController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllPersonalDetailsParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllPersonalDetailsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetPersonalDetailByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreatePersonalDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/id
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdatePersonalDetailCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/id
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePersonalDetailByIdCommand { Id = id }));
        }
    }
}
