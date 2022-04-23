using Aula.DDD.CQRS.Query.Application.Extract.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Aula.DDD.CQRS.Query.API.Controllers
{
    [Route("api/extract")]
    [ApiController]
    public class ExtractController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExtractController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ExtractRequest request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(200, response);
        }
    }
}
