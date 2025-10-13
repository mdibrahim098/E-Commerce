namespace OrderingApplication.Orders.Commands.UpdateOrder
{
  public record UpdateOrderCommand(OrderDto Order)
        :ICommand<UpdateOrderResult>;
    public record UpdateOrderResult(bool IsSuccess);

    public class UpdateOrderCommandValidator: AbstractValidator<UpdateOrderCommand>
    {
       public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Order.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("Customerid is required.");
        }

    }


}
