using Application.Trails.Commands.CreateTrail.Mapper;
using Domain;
using Domain.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Events
{
    public class TrailCreatedEventHandler:INotificationHandler<TrailCreatedEvent>
    {
        private readonly ILogger<TrailCreatedEventHandler> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public TrailCreatedEventHandler(ILogger<TrailCreatedEventHandler> logger, IPublishEndpoint publishEndpoint)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }
        public async Task Handle(TrailCreatedEvent notification, CancellationToken cancellationToken)
        {

            await _publishEndpoint.Publish<TrailCreated>(new TrailCreated()
            {
                TrailName = notification.Trail.TrailName,
                TrailDescription = notification.Trail.TrailDescription,
                Distance = notification.Trail.Distance
            }, cancellationToken);
            _logger.LogInformation($"Domain Event: {notification.GetType().Name}");
        }
    }
}
