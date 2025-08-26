namespace BasketAPI.Data
{
    public class CacheBasketRepository(IBasketRepository repository, 
                                       IDistributedCache cache) 
        : IBasketRepository
    {
        public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            var cachedBasket = await cache.GetStringAsync(userName, cancellationToken);
            if (!string.IsNullOrEmpty(cachedBasket))
            {
              return  JsonSerializer.Deserialize<ShoppingCart>(cachedBasket)!;
            }
            var basket =  await repository.GetBasket(userName, cancellationToken);
            await cache .SetStringAsync(userName, JsonSerializer.Serialize(basket), cancellationToken);
            return basket;
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
             await repository.StoreBasket(basket, cancellationToken);
             await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket), cancellationToken);
             return basket;

        }
        public async Task<bool> DeleteBasket(string useName, CancellationToken cancellationToken = default)
        {
             await repository.DeleteBasket(useName, cancellationToken);
             await cache.RemoveAsync(useName, cancellationToken);
             return true;
        }
    }
}
