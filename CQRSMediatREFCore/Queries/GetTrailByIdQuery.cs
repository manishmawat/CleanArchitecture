using CQRSMediatREFCore.Entities;
using MediatR;

namespace CQRSMediatREFCore.Queries
{
    public record GetTrailByIdQuery(Guid Id) : IRequest<Trail?>;
}
