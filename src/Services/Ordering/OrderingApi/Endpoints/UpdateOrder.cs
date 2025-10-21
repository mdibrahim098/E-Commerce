using OrderingApplication.Orders.Commands.UpdateOrder;

namespace OrderingApi.Endpoints
{

    // Accept a updateorderRequest
    // Maps the request to an UpdateOrderCommand
    // Sends the command for processing
    // return a success or error response basec on the outcome

    public record UpdateOrderRequest(OrderDto Order);
    public record UpdateOrderResponse(bool IsSuccess);

    public class UpdateOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {

            app.MapPut("/orders", async (UpdateOrderRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateOrderCommand>();

                var result = await sender.Send(command);

                var response = result.Adapt<UpdateOrderResponse>();

                return Results.Ok(response);

            })
              .WithName("UpdateOrder")
              .Produces<UpdateOrderResponse>(StatusCodes.Status200OK)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .WithSummary("Update Order")
              .WithDescription("Update Order");

        }
    }



}
