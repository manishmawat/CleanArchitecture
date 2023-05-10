using CQRSMediatREFCore.Data.Repository;
using CQRSMediatREFCore.Entities;
using CQRSMediatREFCore.Queries;
using MediatR;

namespace CQRSMediatREFCore.Handlers.QueryHandlers
{
    public class GetTrailByIdQueryHandler:IRequestHandler<GetTrailByIdQuery,Trail>
    {
        private readonly ITrailRepository _trailRepository;
        public GetTrailByIdQueryHandler(ITrailRepository trailRepository) => _trailRepository = trailRepository;
        public async Task<Trail?> Handle(GetTrailByIdQuery request, CancellationToken cancellationToken)
        {
            return await _trailRepository.GetTrail(request.Id);
        }
    }
}
