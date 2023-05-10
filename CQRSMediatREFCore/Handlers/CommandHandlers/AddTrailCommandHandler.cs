using CQRSMediatREFCore.Command;
using CQRSMediatREFCore.Data.Repository;
using MediatR;

namespace CQRSMediatREFCore.Handlers.CommandHandlers
{
    public class AddTrailCommandHandler:IRequestHandler<AddTrailCommand,Guid>
    {
        private readonly ITrailRepository _trailRepository;
        public AddTrailCommandHandler(ITrailRepository trailRepository)
        {
            _trailRepository = trailRepository;
        }
        public async Task<Guid> Handle(AddTrailCommand request, CancellationToken cancellationToken)
        {
            var newTrailId = await _trailRepository.AddTrail(request.Trail);
            return newTrailId;
        }
    }
}
