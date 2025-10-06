using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace OrderingInfrastrueture.Data.Interceptors
{
    public class DispatchDomainEventInterceptor(IMediator mediator) 
               : SaveChangesInterceptor
    {

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            DispatchDomainEvents(eventData.Context).GetAwaiter().GetResult();
            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            await DispatchDomainEvents(eventData.Context);
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        public async Task DispatchDomainEvents(DbContext? context)
        {
            if(context == null) return;
            var aggregates = context.ChangeTracker
                .Entries<IAggregate>()
                .Where(e => e.Entity.DomainEvents.Any())
                .Select(e => e.Entity);

            var domainEvenets = aggregates
                .SelectMany(e => e.DomainEvents)
                .ToList();

            aggregates.ToList().ForEach(e => e.ClearDomainEvents());

           foreach (var domainEvent in domainEvenets)
            {
                await mediator.Publish(domainEvent);
            }
        }


    }


}
