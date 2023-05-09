using CQRSMediatREFCore.Command;
using CQRSMediatREFCore.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRSMediatREFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TrailController(IMediator mediator) => _mediator = mediator;
        [HttpGet(Name = "GetAllTrails")]
        public async Task<ActionResult> AllTrails()
        {
            var response = await _mediator.Send(new GetAllTrailsQuery());
            return Ok(response);
        }

        [HttpGet(template:"{id:Guid}",Name = "GetTrailById")]
        public async Task<ActionResult> GetTrailById(Guid id)
        {
            var response = await _mediator.Send(new GetTrailByIdQuery(id));
            return Ok(response);
        }

        [HttpPost(Name = "AddTrail")]
        public async Task<ActionResult> AddTrail([FromBody] AddTrailCommand command)
        {
            var response = await _mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
