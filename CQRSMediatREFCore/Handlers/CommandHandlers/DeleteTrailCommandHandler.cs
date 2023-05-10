using CQRSMediatREFCore.Command;
using CQRSMediatREFCore.Data.Repository;
using MediatR;

namespace CQRSMediatREFCore.Handlers.CommandHandlers
{
    public class DeleteTrailCommandHandler:IRequestHandler<DeleteTrailCommand,bool>
    {
        private readonly ITrailRepository _trailRepository;
        public DeleteTrailCommandHandler(ITrailRepository trailRepository)
        {
            _trailRepository = trailRepository;
        }

        public async Task<bool> Handle(DeleteTrailCommand request, CancellationToken cancellationToken)
        {
            return await _trailRepository.DeleteTrail(request.Id);
        }
    }
}
