using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Trails.Commands
{
    public record DeleteTrailCommand(Guid id) : IRequest;

    public class DeleteTrailCommandHandler:IRequestHandler<DeleteTrailCommand>
    {
        public Task Handle(DeleteTrailCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
