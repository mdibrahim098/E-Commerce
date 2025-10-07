using BuildingBlocks.CQRS;

namespace OrderingApplication.Orders.Commands.CreateOrder
{
    public class CreateOrderHandler
        : ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

           // crete order entity from command object
           // save to database
           // return result

            throw new NotImplementedException();
        }
    }
}
