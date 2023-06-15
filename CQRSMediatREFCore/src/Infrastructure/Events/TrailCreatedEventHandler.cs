using Application.Trails.Commands.CreateTrail.Mapper;
using Domain;
using Domain.Events;
using Infrastructure.Email;
using Infrastructure.Utility;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace Infrastructure.Events
{
    public class TrailCreatedEventHandler:INotificationHandler<TrailCreatedEvent>
    {
        private readonly ILogger<TrailCreatedEventHandler> _logger;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configuration;

        public TrailCreatedEventHandler(ILogger<TrailCreatedEventHandler> logger, IPublishEndpoint publishEndpoint, IEmailSender emailSender, IConfiguration configuration)
        {
            _logger = logger;
            _publishEndpoint = publishEndpoint;
            _emailSender = emailSender;
            _configuration = configuration;
        }
        public async Task Handle(TrailCreatedEvent notification, CancellationToken cancellationToken)
        {
            //Send event message to Message Broker / Transport
            await _publishEndpoint.Publish<TrailCreated>(new TrailCreated()
            {
                TrailName = notification.Trail.TrailName,
                TrailDescription = notification.Trail.TrailDescription,
                Distance = notification.Trail.Distance
            }, cancellationToken);
            _logger.LogInformation($"Domain Event: {notification.GetType().Name}");

            if(_configuration.GetValue<bool>(Constants.TrailCreated_IsEmailSenderEnabled))
            {
                //Send email
                var emailMessage = new EmailMessage(
                    new MailboxAddress("email", _configuration.GetValue<string>(Constants.TrailCreated_FromEmail)),
                    "Hello From TailWalker!",
                    "A new trail has been added to the system");

                await _emailSender.SendEmail(emailMessage);
            }
        }
    }
}
