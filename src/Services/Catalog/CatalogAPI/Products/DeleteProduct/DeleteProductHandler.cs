
namespace CatalogAPI.Products.DeleteProduct
{

    public record DeleteProductCommand(Guid Id): ICommand<DeleteProductResult>;
    public record DeleteProductResult(bool IsSuccess);
      
    public class DeleteProductCommandValidator 
        : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator ()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id is required.");
        }
    }


    internal class DeleteProductCommandHandler (IDocumentSession session)
        : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand Command, CancellationToken cancellationToken)
        {
            
            session.Delete<Product>(Command.Id);
            await session.SaveChangesAsync();

            return new DeleteProductResult(true);

        }
    }


}
