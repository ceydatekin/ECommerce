using ECommerce.BasketService.Core.Entities;

namespace ECommerce.BasketService.Core.Interfaces;

public interface IBasketRepository
{
    Task<Basket> GetBasketAsync(string userId);

    Task AddToBasketAsync(string userId, BasketItem item);

    Task UpdateBasketItemAsync(string userId, BasketItem item);

    Task RemoveFromBasketAsync(string userId, string productId);

    Task ClearBasketAsync(string userId);

    Task SetBasketExpirationAsync(string userId, TimeSpan expirationTime);

    Task<List<Basket>> GetAllBasketsAsync();

    Task UpdateBasketAsync(Basket basket);
}