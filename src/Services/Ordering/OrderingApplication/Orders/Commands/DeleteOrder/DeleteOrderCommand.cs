namespace OrderingApplication.Orders.Commands.DeleteOrder
{

    public record DeleteOrderCommand(Guid OrderId)
        :ICommand<DeleteOrderResult>;

    public record DeleteOrderResult(bool IsSuccess);


    public class DleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
    {
        public DleteOrderCommandValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId is required.");
        }


    }

}
