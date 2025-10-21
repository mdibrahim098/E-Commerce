using OrderingApplication.Orders.Queries.GetOrdersByCustomers;


namespace OrderingApi.Endpoints
{
    // Accept a Customer ID.
    // uses a GetOrdersByCustomerQuery to fetch ordersa.
    // Return the list of orders for that customer.

    // public record GetOrderByCustomerRequest(Guid CustomerId);
    public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);



    public class GetOrdersByCustomer : ICarterModule
    {


        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/customer/{customerId}", async (Guid customerId, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersByCustomerQuery(customerId));

                var response = result.Adapt<GetOrdersByCustomerResponse>();

                return Results.Ok(response);
            })
            .WithName("GetOrdersByCustomer")
            .Produces<GetOrdersByCustomerResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Orders By Customer")
            .WithDescription("Get Orders By Customer");
        }
    }

}
