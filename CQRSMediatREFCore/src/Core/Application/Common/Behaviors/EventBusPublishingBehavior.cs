using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Events;
using MediatR;

namespace Application.Common.Behaviors
{
    public class EventBusPublishingBehavior<TRequest,TResponse>:IPipelineBehavior<TRequest,TResponse> where TRequest:IRequest<TResponse>
    {
        private readonly IEventBus _eventBus;
        public EventBusPublishingBehavior(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();

            await _eventBus.FlushAllAsync(cancellationToken);

            return response;
        }
    }
}
