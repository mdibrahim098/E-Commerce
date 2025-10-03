namespace OrderingDomain.Events
{
    public record OrderCreatedEvent(Order order) : IDomainEvent;


}
