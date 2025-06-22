
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


    internal class DeleteProductCommandHandler
        (IDocumentSession session, ILogger<DeleteProductCommandHandler> logger)
        : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand Command, CancellationToken cancellationToken)
        {
             logger.LogInformation("DeleteProductCommandHandler.Handle called with {@Command}", Command);

            session.Delete<Product>(Command.Id);
            await session.SaveChangesAsync();

            return new DeleteProductResult(true);

        }
    }


}
