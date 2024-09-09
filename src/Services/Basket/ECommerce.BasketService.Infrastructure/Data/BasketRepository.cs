using System.Text.Json;
using ECommerce.BasketService.Core.Entities;
using ECommerce.BasketService.Core.Interfaces;
using StackExchange.Redis;

namespace ECommerce.BasketService.Infrastructure.Data;

public class BasketRepository : IBasketRepository
{
    private readonly IConnectionMultiplexer _redis;

    private readonly IDatabase _database;

    public BasketRepository(IConnectionMultiplexer redis)
    {
        _redis = redis;
        _database = redis.GetDatabase();
    }

    public async Task<Basket> GetBasketAsync(string userId)
    {
        var basketJson = await _database.StringGetAsync(GetBasketKey(userId));

        return basketJson.IsNullOrEmpty
            ? new Basket { UserId = userId }
            : JsonSerializer.Deserialize<Basket>(basketJson);
    }

    public async Task AddToBasketAsync(string userId, BasketItem item)
    {
        var basket = await GetBasketAsync(userId);
        var existingItem = basket.Items.FirstOrDefault(i => i.ProductId == item.ProductId);

        if (existingItem != null)
        {
            existingItem.Quantity += item.Quantity;
        }
        else
        {
            basket.Items.Add(item);
        }

        await SaveBasketAsync(basket);
    }

    public async Task UpdateBasketItemAsync(string userId, BasketItem item)
    {
        var basket = await GetBasketAsync(userId);
        var existingItem = basket.Items.FirstOrDefault(i => i.ProductId == item.ProductId);

        if (existingItem != null)
        {
            existingItem.Quantity = item.Quantity;
            existingItem.Price = item.Price;
            existingItem.ProductName = item.ProductName;
        }

        await SaveBasketAsync(basket);
    }

    public async Task RemoveFromBasketAsync(string userId, string productId)
    {
        var basket = await GetBasketAsync(userId);
        basket.Items.RemoveAll(i => i.ProductId == productId);
        await SaveBasketAsync(basket);
    }

    public async Task ClearBasketAsync(string userId)
    {
        await _database.KeyDeleteAsync(GetBasketKey(userId));
    }

    private async Task SaveBasketAsync(Basket basket)
    {
        var basketJson = JsonSerializer.Serialize(basket);
        await _database.StringSetAsync(GetBasketKey(basket.UserId), basketJson);
    }

    private string GetBasketKey(string userId) => $"cart:{userId}";
}