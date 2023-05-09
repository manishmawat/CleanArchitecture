    using CQRSMediatREFCore.Entities;
    using MediatR;

    namespace CQRSMediatREFCore.Queries
    {
        public record GetAllTrailsQuery() : IRequest<IEnumerable<Trail>>;
    }