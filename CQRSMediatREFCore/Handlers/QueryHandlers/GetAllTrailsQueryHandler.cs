﻿using CQRSMediatREFCore.Data.Repository;
using CQRSMediatREFCore.Entities;
using CQRSMediatREFCore.Queries;
using MediatR;

namespace CQRSMediatREFCore.Handlers.QueryHandlers
{
    public class GetAllTrailsQueryHandler:IRequestHandler<GetAllTrailsQuery,IEnumerable<Trail>>
    {
        private readonly ITrailRepository _trailRepository;
        public GetAllTrailsQueryHandler(ITrailRepository trailRepository)
        {
            _trailRepository = trailRepository;
        }


        public async Task<IEnumerable<Trail>> Handle(GetAllTrailsQuery request, CancellationToken cancellationToken)
        {
            return await _trailRepository.GetTrails();
        }
    }
}
