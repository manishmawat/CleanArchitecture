using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Application.CycleTrails.Commands;
using Application.CycleTrails.Commands.CreateCycleTrail;
using Application.CycleTrails.Queries;
using Mapster;
using MediatR;

namespace Presentation.Controllers
{
    /// <summary>
    /// Cycle trail Controller
    /// </summary>
    public sealed class CycleTrailController: ApiController
    {
        /// <summary>
        /// Retrieve a Cycle Trail from the system
        /// </summary>
        /// <param name="cycleTrailId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{cycleTrail:guid}")]
        [ProducesResponseType(typeof(CycleTrailResponse),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCycleTrail(Guid cycleTrailId, CancellationToken cancellationToken)
        {
            var query = new GetCycleTrailByIdQuery(cycleTrailId);
            var cycleTrail = await Sender.Send(query, cancellationToken);
            return Ok(cycleTrail);
        }

        /// <summary>
        /// Creates newCycle Trail in the system
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCycleTrail(
            [FromBody] CreateCycleTrailRequest request,
            CancellationToken cancellationToken)
        {
            var command = request.Adapt<CreateCycleTrailCommand>();
            var cycleTrailId = await Sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetCycleTrail), new { cycleTrailId }, cycleTrailId);

        }
    }
}
