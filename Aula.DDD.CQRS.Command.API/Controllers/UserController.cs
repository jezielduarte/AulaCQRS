using Aula.DDD.CQRS.Application.User.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Command.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> Put(Guid userId, [FromBody] UpdateUserCommand command)
        {
            command.SetId(userId);
            var response = await _mediator.Send(command);
            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var response = await _mediator.Send(new DeleteUserCommand(userId));
            return StatusCode(response.StatusCode, response);
        }
    }
}
