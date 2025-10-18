using OrderingApplication.Orders.Queries.GetOrdersByCustomers;


namespace OrderingApi.Endpoints
{
    // Accept a Customer ID.
    // uses a GetOrdersByCustomerQuery to fetch ordersa.
    // Return the list of orders for that customer.

    // public record GetOrderByCustomerRequest(Guid CustomerId);
    public record GetOrderByCustomerResponse(IEnumerable<OrderDto> Orders);



    public class GetOrdersByCustomer : ICarterModule
    {


        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/customer/{CustomerId}", async (Guid CustomerId, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersByCustomerQuery(CustomerId));

                var response = result.Adapt<GetOrderByCustomerResponse>();

                return Results.Ok(response);
            })
              .WithName("GetOrderByCustomerId")
              .Produces<GetOrderByCustomerResponse>(StatusCodes.Status200OK)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .ProducesProblem(StatusCodes.Status404NotFound)
              .WithSummary("Get Order By Customer")
              .WithDescription("Get Order By Customer");


        }
    }

}
