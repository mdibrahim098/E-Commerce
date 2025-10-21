
using OrderingApplication.Orders.Commands.DeleteOrder;

namespace OrderingApi.Endpoints
{
    // Accept a orderID as a parameter
    // Constructs DeleteOrderCommand
    // Sends the command to the mediator
    // return a success or not found result

    // Public record DeleteOrderRuquest(Guid Id);
    public record DeleteOrderResponse(bool IsSuccess);

    public class DeleteOrder : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/orders/{id}", async (Guid Id, IMediator mediator) =>
            {
                
                var result = await mediator.Send(new DeleteOrderCommand(Id));
               
                var response = result.Adapt<DeleteOrderResponse>();

                return Results.Ok(response);
            })
              .WithName("DeleteOrder")
              .Produces<DeleteOrderResponse>(StatusCodes.Status200OK)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .ProducesProblem(StatusCodes.Status404NotFound)
              .WithSummary("Delete Order")
              .WithDescription("Delete Order");
        }
    }

}
