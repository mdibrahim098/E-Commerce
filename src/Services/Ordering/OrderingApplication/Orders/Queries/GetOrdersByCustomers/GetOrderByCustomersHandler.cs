
namespace OrderingApplication.Orders.Queries.GetOrdersByCustomers
{
    public class GetOrderByCustomersHandler(IApplicationDbContext dbContxt)
         : IQueryHandler<GetOrdersByCustomerQuery, GetOrderByCustomerResult>
    {
        public async Task<GetOrderByCustomerResult> Handle(GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
        {

            var orders = await dbContxt.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking()
                .Where(o => o.CustomerId == CustomerId.Of(query.CustomerId))
                .OrderBy(o => o.OrderName)
                .ToListAsync(cancellationToken);

            return new GetOrderByCustomerResult(orders.ToOrderDtoList());
        }
    }
}

