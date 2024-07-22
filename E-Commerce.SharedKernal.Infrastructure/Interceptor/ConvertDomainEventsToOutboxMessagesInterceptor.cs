using E_Commerce.SharedKernal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace E_Commerce.SharedKernal.Infrastructure.Interceptor
{
    public class ConvertDomainEventsToOutboxMessagesInterceptor : SaveChangesInterceptor
    {
        private readonly IPublisher _publisher;

        public ConvertDomainEventsToOutboxMessagesInterceptor(IPublisher publisher)
        {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
                                                                           InterceptionResult<int> result,
                                                                           CancellationToken cancellationToken = default)
        {
            var dbContext = eventData.Context;
            var entities = dbContext.ChangeTracker.Entries<IHasDomainEvents>()
                .Where(x => x.Entity.DomainEvents.Any())
                .ToList();

            if(entities.Count() == 0)
            {
               return await base.SavingChangesAsync(eventData, result, cancellationToken);
            }
            using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                var domainResult = await PublishDomainEvents(dbContext, cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                if (domainResult)
                {
                    return await base.SavingChangesAsync(eventData, result, cancellationToken);
                   //await dbContext.SaveChangesAsync(cancellationToken);
                }
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);
                return InterceptionResult<int>.SuppressWithResult(0);
            }

            return InterceptionResult<int>.SuppressWithResult(0);
        }

        private async Task<bool> PublishDomainEvents(DbContext dbContext, CancellationToken cancellationToken)
        {
            var entities = dbContext.ChangeTracker.Entries<IHasDomainEvents>()
                .Where(x => x.Entity.DomainEvents.Any())
                .ToList();

            //if (!entities.Any())
            //    return false;

            var errors = new List<Exception>();
            var domainEvents = entities.SelectMany(x => x.Entity.DomainEvents).ToList();
            var hasPublishedEvents = false;

            foreach (var entity in entities)
            {
                entity.Entity.ClearDomainEvents();
            }

            foreach (var domainEvent in domainEvents)
            {
                try
                {
                    await _publisher.Publish(domainEvent, cancellationToken);
                }
                catch (Exception ex)
                {
                    errors.Add(ex);
                    return false;
                }
            }

            return true;
        }
    }
}
