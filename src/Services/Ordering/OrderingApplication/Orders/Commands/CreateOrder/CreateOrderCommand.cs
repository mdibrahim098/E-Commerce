using BuildingBlocks.CQRS;
using FluentValidation;
using OrderingApplication.Dtos;

namespace OrderingApplication.Orders.Commands.CreateOrder
{
    public record CreateOrderCommand(OrderDto Order)
        : ICommand<CreateOrderResult>;
    public record CreateOrderResult(Guid Id);
    public class CreateorderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateorderCommandValidator()
        {

            RuleFor(x => x.Order.OrderName).NotEmpty().WithMessage("Name is required.");
            RuleFor(x => x.Order.CustomerId).NotNull().WithMessage("CustomerId is required.");
            RuleFor(x => x.Order.OrderItems).NotEmpty().WithMessage("OrderItems should not empty.");
      
        }     
      
    }

}
