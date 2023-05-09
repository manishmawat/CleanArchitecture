using CQRSMediatREFCore.Command;
using CQRSMediatREFCore.Repository;
using MediatR;

namespace CQRSMediatREFCore.Handlers.CommandHandlers
{
    public class DeleteTrailCommandHandler:IRequestHandler<DeleteTrailCommand,bool>
    {
        private readonly IRepository _repository;
        public DeleteTrailCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteTrailCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteTrail(request.Id);
        }
    }
}
