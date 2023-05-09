using CQRSMediatREFCore.Entities;
using CQRSMediatREFCore.Queries;
using CQRSMediatREFCore.Repository;
using MediatR;

namespace CQRSMediatREFCore.Handlers.QueryHandlers
{
    public class GetAllTrailsQueryHandler:IRequestHandler<GetAllTrailsQuery,IEnumerable<Trail>>
    {
        private readonly IRepository _repository;
        public GetAllTrailsQueryHandler(IRepository repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<Trail>> Handle(GetAllTrailsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetTrails();
        }
    }
}
