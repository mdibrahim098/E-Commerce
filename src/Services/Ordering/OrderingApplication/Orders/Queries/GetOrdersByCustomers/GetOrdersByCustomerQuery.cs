namespace OrderingApplication.Orders.Queries.GetOrdersByCustomers
{

    public record GetOrdersByCustomerQuery(Guid CustomerId)
        :IQuery<GetOrderByCustomerResult>;
    public record GetOrderByCustomerResult(IEnumerable<OrderDto> orders);

}
