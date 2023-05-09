using MediatR;

namespace CQRSMediatREFCore.Command
{
    public record DeleteTrailCommand(Guid Id) : IRequest<bool>;
}
