using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using MediatR;

namespace Application.Trails.Commands
{
    public record UpdateTrailCommand(Trail trail) : IRequest<Trail>;

    public class UpdateTrailCommandHandler:IRequestHandler<UpdateTrailCommand,Trail>
    {
        public Task<Trail> Handle(UpdateTrailCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
