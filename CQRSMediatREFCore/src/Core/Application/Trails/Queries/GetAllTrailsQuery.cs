using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain;
using MediatR;

namespace Application.Trails.Queries
{
    public record GetAllTrailsQuery : IRequest<IEnumerable<Trail>>;

    public class GetAllTrailsQueryHandler : IRequestHandler<GetAllTrailsQuery, IEnumerable<Trail>>
    {
        private readonly ITrailRepository _trailRepository;

        public GetAllTrailsQueryHandler(ITrailRepository trailRepository)
        {
            _trailRepository = trailRepository ?? throw new ArgumentNullException();
        }
        public Task<IEnumerable<Trail>> Handle(GetAllTrailsQuery request, CancellationToken cancellationToken)
        {
            return _trailRepository.GetTrails();
        }
    }
}
