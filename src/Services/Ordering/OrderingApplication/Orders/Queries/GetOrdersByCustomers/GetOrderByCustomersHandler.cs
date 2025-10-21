
using Microsoft.EntityFrameworkCore;

namespace OrderingApplication.Orders.Queries.GetOrdersByCustomers
{
    public class GetOrderByCustomersHandler(IApplicationDbContext dbContext)
         : IQueryHandler<GetOrdersByCustomerQuery, GetOrderByCustomerResult>
    {
        public async Task<GetOrderByCustomerResult> Handle(GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
        {
            var orders = await dbContext.Orders
                              .Include(o => o.OrderItems)
                              .AsNoTracking()
                              .Where(o => o.CustomerId == CustomerId.Of(query.CustomerId))
                              .OrderBy(o => o.OrderName.Value)
                              .ToListAsync(cancellationToken);

            return new GetOrderByCustomerResult(orders.ToOrderDtoList());
        }
    }
}

