using CQRSMediatREFCore.Command;
using CQRSMediatREFCore.Entities;
using CQRSMediatREFCore.Repository;
using MediatR;

namespace CQRSMediatREFCore.Handlers.CommandHandlers
{
    public class UpdateTrailCommandHandler:IRequestHandler<UpdateTrailCommand,Trail>
    {
        private readonly IRepository _repository;

        public UpdateTrailCommandHandler(IRepository repository) => _repository = repository;


        public async Task<Trail> Handle(UpdateTrailCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateTrail(request.Trail);
        }
    }
}
