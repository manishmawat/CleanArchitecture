using Application.CycleTrails.Commands.CreateCycleTrail;
using Trails.Application.Abstractions.Messaging;
using Trails.Domain.Abstractions;

namespace Trails.Application.CycleTrails.Commands.CreateCycleTrail
{
    internal sealed class CreateCycleTrailCommandHandler : ICommandHandler<CreateCycleTrailCommand, Guid>
    {
        public Task<Guid> Handle(CreateCycleTrailCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
