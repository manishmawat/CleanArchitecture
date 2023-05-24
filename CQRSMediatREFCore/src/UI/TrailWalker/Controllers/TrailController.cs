using Application.Trails.Commands;
using Application.Trails.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrailWalker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TrailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Trail>> GetTrails()
        {
            return await _mediator.Send(new GetAllTrailsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> AddTrail(CreateTrailCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
