
namespace BasketAPI.Data
{
    public class CacheBasketRepository(IBasketRepository repositoiry) 
        : IBasketRepository
    {
        public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
           return await repositoiry.GetBasket(userName, cancellationToken);
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            return await repositoiry.StoreBasket(basket, cancellationToken);
        }
        public async Task<bool> DeleteBasket(string useName, CancellationToken cancellationToken = default)
        {
            return await repositoiry.DeleteBasket(useName, cancellationToken);
        }
    }
}
