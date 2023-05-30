using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain;
using MediatR;

namespace Application.Trails.Queries
{
    public record GetTrailByIdQuery(Guid trailId) : IRequest<Trail?>;

    public class GetTrailByIdQueryHandler : IRequestHandler<GetTrailByIdQuery, Trail?>
    {
        private readonly ITrailRepository _trailRepository;

        public GetTrailByIdQueryHandler(ITrailRepository trailRepository)
        {
            _trailRepository = trailRepository;
        }
        public Task<Trail?> Handle(GetTrailByIdQuery request, CancellationToken cancellationToken)
        {
            if (request is not null)
            {
                return _trailRepository.GetTrail(request.trailId);
            }

            //TODO:Add Response Value type
            return null;
        }
    }
}
