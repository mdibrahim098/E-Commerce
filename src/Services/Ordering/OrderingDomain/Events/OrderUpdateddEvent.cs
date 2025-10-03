namespace OrderingDomain.Events
{
    public record OrderUpdateddEvent(Order order) : IDomainEvent;



}
