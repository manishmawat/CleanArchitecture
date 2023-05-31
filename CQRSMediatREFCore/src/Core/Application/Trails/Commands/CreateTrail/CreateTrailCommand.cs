using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain;
using Domain.Common;
using Domain.Events;
using MediatR;

namespace Application.Trails.Commands
{
    public record CreateTrailCommand:IRequest<Guid>, ICommand
    {
        //public City City { get; set; }
        public string TrailName { get; set; }
        public string TrailDescription { get; set; }
        public double Distance { get; set; }
    }

    public class CreateTrailCommandHandler:IRequestHandler<CreateTrailCommand,Guid>
    {
        private readonly ITrailRepository _trailRepository;

        public CreateTrailCommandHandler(ITrailRepository trailRepository)
        {
            _trailRepository = trailRepository?? throw new ArgumentNullException(nameof(trailRepository));
        }
        public Task<Guid> Handle(CreateTrailCommand request, CancellationToken cancellationToken)
        {
            //Use automapper here
            var trail = new Trail()
            {
                TrailName = request.TrailName,
                Distance = request.Distance,
                TrailDescription = request.TrailDescription,
            };

            trail.AddDomainEvent(new TrailCreatedEvent(trail));
            return _trailRepository.AddTrail(trail);
        }
    }
}
