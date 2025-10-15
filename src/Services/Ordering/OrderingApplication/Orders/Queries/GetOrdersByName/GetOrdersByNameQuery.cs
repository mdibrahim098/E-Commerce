namespace OrderingApplication.Orders.Queries.GetOrdersByName
{
   public record GetOrdersByNameQuery(string UserName) 
        : IQuery<GetOrdersByNameResult>;
    public record GetOrdersByNameResult(IEnumerable<OrderDto> Orders);

}
