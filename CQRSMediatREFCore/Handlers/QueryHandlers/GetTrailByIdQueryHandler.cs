using CQRSMediatREFCore.Entities;
using CQRSMediatREFCore.Queries;
using CQRSMediatREFCore.Repository;
using MediatR;

namespace CQRSMediatREFCore.Handlers.QueryHandlers
{
    public class GetTrailByIdQueryHandler:IRequestHandler<GetTrailByIdQuery,Trail>
    {
        private readonly IRepository _repository;
        public GetTrailByIdQueryHandler(IRepository repository) => _repository = repository;
        public async Task<Trail?> Handle(GetTrailByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetTrail(request.Id);
        }
    }
}
