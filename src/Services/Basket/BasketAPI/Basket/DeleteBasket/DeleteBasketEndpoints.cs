
using BasketAPI.Basket.StoreBasket;

namespace BasketAPI.Basket.DeleteBasket
{

   // public record DeleteBasketResult(string UserName);
    public record DeleteBasketResponse(bool IsSuccess);


    public class DeleteBasketEndpoints : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/basket/{userName}", async (string userName, ISender sender) =>
            {

                var result = await sender.Send(new DeleteBasketCommand(userName));

                var response = result.Adapt<DeleteBasketResponse>();


                return Results.Ok(response);

            })
              .WithName("DeleteProduct")
              .Produces<DeleteBasketResponse>(StatusCodes.Status201Created)
              .ProducesProblem(StatusCodes.Status400BadRequest)
              .ProducesProblem(StatusCodes.Status404NotFound)
              .WithSummary("Delete Product")
              .WithDescription("Delete Product");

        }
    }
}
