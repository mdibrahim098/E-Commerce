
using MediatR;
using OrderingApplication.Orders.Queries.GetOrdersByName;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace OrderingApi.Endpoints
{

    // Accept a name parameters
    // Constructs a GetorderBynameQuery.
    // Retrives and return matching orders.

   // public record GetOrderByNameRequest(string Name);
    public record GetOrderByNameResponse(IEnumerable<OrderDto> Orders);


    public class GetOrdersByName : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/orders/{orderName}", async (string orderName, ISender sender) =>
            {
                var result = await sender.Send(new GetOrdersByNameQuery(orderName));
                var response = result.Adapt<GetOrderByNameResponse>();
                return Results.Ok(response);
            })
              .WithName("GetOrderByName")
              .Produces<GetOrderByNameResponse>(StatusCodes.Status200OK)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .ProducesProblem(StatusCodes.Status404NotFound)
              .WithSummary("Get Order By name")
              .WithDescription("Get Order By name");
        }
    }
}
