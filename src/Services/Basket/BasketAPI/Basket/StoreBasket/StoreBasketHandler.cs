
using DiscountGrpc;

namespace BasketAPI.Basket.StoreBasket
{

    public record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketResult>;
    public record StoreBasketResult(string UserName);

    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.Cart).NotNull().WithMessage("cart cannot be null.");
            RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required.");

        }

    }

    public class StoreBasketCommandHandler(IBasketRepository repository,
        DiscountProtoService.DiscountProtoServiceClient discountProto) 
        :  ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
        {

            await DeductDicount(command.Cart, cancellationToken);

            await repository.StoreBasket(command.Cart, cancellationToken);

            return new StoreBasketResult(command.Cart.UserName);

        }
         
        private async Task DeductDicount(ShoppingCart cart, CancellationToken cancellationToken)
        {

            // communicate with discount grpc and calculate latest price of product
            foreach(var item in cart.Items)
            {
                var coupon = await discountProto.GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName }, cancellationToken: cancellationToken);
                item.Price -= coupon.Amount;

            }


        }


    }

}
