using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Common
{
    public static class MediaExtensions_DispatchDomainEvents
    {
        public static async Task DispatchDomainEvent(this IMediator mediator, DbContext context)
        {
            var entities = context.ChangeTracker
                .Entries<BaseEntity>()
                .Where(e => e.Entity.DomainEvents.Any())
                .Select(e => e.Entity);

            var domainEvents=entities
                .SelectMany(e=>e.DomainEvents)
                .ToList();

            entities.ToList().ForEach(e=>e.ClearDomainEvents());

            foreach (var domainEvent in domainEvents)
            {
                await mediator.Publish(domainEvent);
            }
        }
    }
}
