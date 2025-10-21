using BuildingBlocks.Pagination;
using OrderingApplication.Orders.Queries.GetOrders;

namespace OrderingApi.Endpoints
{

    // Accept pagination parameters.
    // Constructs a GetOrderQuery with these parameters
    // Retrives the data and return it in a paginated format.

    // public record GetOrdersRequest(PaginationRequest PaginationRequest

    public  record GetOrdersResponse(PaginatedResult<OrderDto> Orders);


    public class GetOrders : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
          app.MapGet("/orders", async ([AsParameters] PaginationRequest request, ISender sender) =>
          {

              var result = await sender.Send(new GetOrdersQuery(request));

              var response = result.Adapt<GetOrdersResponse>();

              return Results.Ok(response);
          })
              .WithName("GetOrders")
              .Produces<GetOrdersResponse>(StatusCodes.Status200OK)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .ProducesProblem(StatusCodes.Status404NotFound)
              .WithSummary("Get Orders")
              .WithDescription("Get Order");



        }
    }

}
