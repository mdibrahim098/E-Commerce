
namespace BasketAPI.Data
{
    public class BasketRepository : IBasketRepository
    {

        public Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteBasket(string useName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

    }
}
