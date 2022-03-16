using Aula.DDD.CQRS.Application.Accounts.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Command.API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("open-savings-account")]
        public async Task<IActionResult> OpenSavingsAccount([FromBody] OpenSavingsAccountCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("open-checking-account")]
        public async Task<IActionResult> OpenCheckingAccount([FromBody] OpenCheckingAccountCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] OpenSavingsAccountCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] OpenCheckingAccountCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("release-overdraft")]
        public async Task<IActionResult> ReleaseOverdraft([FromBody] OpenCheckingAccountCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode(response.StatusCode, response);
        }

    }
}
