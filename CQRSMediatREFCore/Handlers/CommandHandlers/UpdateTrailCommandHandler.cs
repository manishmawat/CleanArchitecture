using CQRSMediatREFCore.Command;
using CQRSMediatREFCore.Data.Repository;
using CQRSMediatREFCore.Entities;
using MediatR;

namespace CQRSMediatREFCore.Handlers.CommandHandlers
{
    public class UpdateTrailCommandHandler:IRequestHandler<UpdateTrailCommand,Trail>
    {
        private readonly ITrailRepository _trailRepository;

        public UpdateTrailCommandHandler(ITrailRepository trailRepository) => _trailRepository = trailRepository;


        public async Task<Trail> Handle(UpdateTrailCommand request, CancellationToken cancellationToken)
        {
            return await _trailRepository.UpdateTrail(request.Trail);
        }
    }
}
