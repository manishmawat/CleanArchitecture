using CQRSMediatREFCore.Command;
using CQRSMediatREFCore.Repository;
using MediatR;

namespace CQRSMediatREFCore.Handlers.CommandHandlers
{
    public class AddTrailCommandHandler:IRequestHandler<AddTrailCommand,Guid>
    {
        private readonly IRepository _repository;
        public AddTrailCommandHandler(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<Guid> Handle(AddTrailCommand request, CancellationToken cancellationToken)
        {
            var newTrailId = await _repository.AddTrail(request.Trail);
            return newTrailId;
        }
    }
}
