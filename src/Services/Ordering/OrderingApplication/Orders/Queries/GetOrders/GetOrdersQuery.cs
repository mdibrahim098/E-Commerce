namespace OrderingApplication.Orders.Queries.GetOrders
{

    public record GetOrdersQuery(PaginatedRequest PaginationRequest)
        : IQuery<GetOrdersResult>;
    public record GetOrdersResult(PaginatedResult<OrderDto> Orders);

}
