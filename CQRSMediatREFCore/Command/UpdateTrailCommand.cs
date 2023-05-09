using CQRSMediatREFCore.Entities;
using MediatR;

namespace CQRSMediatREFCore.Command
{
    public record UpdateTrailCommand(Trail Trail) : IRequest<Trail>;
}
