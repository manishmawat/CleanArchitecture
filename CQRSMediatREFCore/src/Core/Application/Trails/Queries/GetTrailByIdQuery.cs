using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Contracts;
using Domain;
using Domain.Maybe;
using MediatR;

namespace Application.Trails.Queries
{
    public record GetTrailByIdQuery(Guid TrailId) : IRequest<Maybe<TrailByIdResponse>>;

    public class GetTrailByIdQueryHandler : IRequestHandler<GetTrailByIdQuery, Maybe<TrailByIdResponse>>
    {
        private readonly ITrailRepository _trailRepository;

        public GetTrailByIdQueryHandler(ITrailRepository trailRepository)
        {
            _trailRepository = trailRepository;
        }

        public async Task<Maybe<TrailByIdResponse>> Handle(GetTrailByIdQuery request,
            CancellationToken cancellationToken)
        {
            if (request.TrailId == default)
            {
                return Maybe<TrailByIdResponse>.None;
            }

            Maybe<Trail> mayBeResponse = await _trailRepository.GetTrail(request.TrailId);

            if (mayBeResponse.HasNoValue)
            {
                return Maybe<TrailByIdResponse>.None;
            }

            Trail trail = mayBeResponse.Value;

            var response = new TrailByIdResponse()
            {
                TrailName = trail.TrailName,
                TrailDescription = trail.TrailDescription,
                Distance = trail.Distance,
                CityName = trail.City?.Name ?? string.Empty
            };

            return response;
        }
    }
}
