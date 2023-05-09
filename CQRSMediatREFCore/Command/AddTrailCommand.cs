using CQRSMediatREFCore.Entities;
using MediatR;

namespace CQRSMediatREFCore.Command
{
    public record AddTrailCommand(Trail Trail) : IRequest<Guid>;
}
