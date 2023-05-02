using Application.Abstractions.Messaging;
using Trails.Application.Abstractions.Messaging;

namespace Application.CycleTrails.Commands.CreateCycleTrail
{
    public sealed record CreateCycleTrailCommand(string name, double distance) : ICommand<Guid>;
}
