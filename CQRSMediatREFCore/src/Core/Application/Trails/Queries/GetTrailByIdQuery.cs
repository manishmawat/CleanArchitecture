using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using MediatR;

namespace Application.Trails.Queries
{
    public record GetTrailByIdQuery(Guid trailId) : IRequest<Trail>;

    public class GetTrailByIdQueryHandler : IRequestHandler<GetTrailByIdQuery, Trail>
    {
        public Task<Trail> Handle(GetTrailByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
