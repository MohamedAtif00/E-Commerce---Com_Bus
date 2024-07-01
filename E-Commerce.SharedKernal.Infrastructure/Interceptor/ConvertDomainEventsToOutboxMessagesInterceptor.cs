using E_Commerce.SharedKernal.Domain;
using E_Commerce.SharedKernal.Infrastructure.OutBox;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.SharedKernal.Infrastructure.Interceptor
{
    public class ConvertDomainEventsToOutboxMessagesInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, 
                                                                              InterceptionResult<int> result, 
                                                                              CancellationToken cancellationToken = default)
        {
            DbContext? dbContext = eventData.Context;

            if (dbContext is null)
            {
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            var domainEvents = dbContext.ChangeTracker
                .Entries<AggregateRoot<ValueObjectId>>()
                .Select(x =>x.Entity)
                .SelectMany(x =>
                    {
                        var domainEvents = x.GetDomainEvents();
                        x.ClearDomainEvents();
                        return domainEvents;
                    } 
                )
                .Select(domainEvent => new OutboxMessage 
                {
                    Id = Guid.NewGuid(),
                    OccurredOnUtc = DateTime.UtcNow,
                    Type = domainEvent.GetType().Name,
                    Content = JsonConvert.SerializeObject(
                        domainEvent,
                        new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All} 
                        )
                })
                .ToList();

            dbContext.Set<OutboxMessage>().AddRange(domainEvents);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
