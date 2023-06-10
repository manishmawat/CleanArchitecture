using Application.Trails.Commands;
using Application.Trails.Queries;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrailWalker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IValidator<CreateTrailCommand> _validator;

        public TrailController(ISender mediator, IValidator<CreateTrailCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }

        [HttpGet]
        public async Task<IEnumerable<Trail>> GetTrails()
        {
            return await _mediator.Send(new GetAllTrailsQuery());
        }

        //[HttpGet]
        //public async Task<ActionResult<Trail>> GetTrail(GetTrailByIdQuery query)
        //{
        //    return await _mediator.Send(query);
        //}

        [HttpPost]
        public async Task<ActionResult<Guid>> AddTrail(CreateTrailCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }
            return await _mediator.Send(command);
            //var result = await _mediator.Send(command);
            //return CreatedAtAction(nameof(AddTrail), new { id = result }, new JsonResponse<Guid>(result));
        }
    }
}
