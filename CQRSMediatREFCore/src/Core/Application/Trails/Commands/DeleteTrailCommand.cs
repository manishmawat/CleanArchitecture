using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Common;
using MediatR;

namespace Application.Trails.Commands
{
    public record DeleteTrailCommand(Guid id) : ICommand<bool>;

    public class DeleteTrailCommandHandler : IRequestHandler<DeleteTrailCommand, bool>
    {
        private readonly ITrailRepository _trailRepository;
        public DeleteTrailCommandHandler(ITrailRepository trailRepository)
        {
            _trailRepository = trailRepository;
        }
        public async Task<bool> Handle(DeleteTrailCommand request, CancellationToken cancellationToken)
        {
            return await _trailRepository.DeleteTrail(request.id);
        }
    }
}
