namespace OrderingApplication.Orders.EventHandlers.Domain
{
    public class OrderUpdatedEventHandler(ILogger<OrderUpdatedEventHandler> logger)
        : INotificationHandler<OrderUpdateddEvent>
    {
        public Task Handle(OrderUpdateddEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handler : {DomainEvent}", notification.GetType().Name);
            return Task.CompletedTask;
        }
    }
}
