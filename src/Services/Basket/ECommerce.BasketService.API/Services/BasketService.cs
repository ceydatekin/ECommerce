using ECommerce.BasketService.Core.Entities;
using ECommerce.BasketService.Core.Interfaces;

namespace ECommerce.BasketService.API.Services;

public class BasketService : IBasketService
{
    private readonly IBasketRepository _basketRepository;

    public BasketService(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }

    public async Task<Basket> GetBasketAsync(string userId)
    {
        return await _basketRepository.GetBasketAsync(userId);
    }

    public async Task AddToBasketAsync(string userId, BasketItem item)
    {
        // Burada ürün bilgilerinin doğruluğunu kontrol edebilirsiniz
        await _basketRepository.AddToBasketAsync(userId, item);
    }

    public async Task UpdateBasketItemAsync(string userId, BasketItem item)
    {
        // Burada ürün bilgilerinin doğruluğunu kontrol edebilirsiniz
        await _basketRepository.UpdateBasketItemAsync(userId, item);
    }

    public async Task RemoveFromBasketAsync(string userId, string productId)
    {
        await _basketRepository.RemoveFromBasketAsync(userId, productId);
    }

    public async Task ClearBasketAsync(string userId)
    {
        await _basketRepository.ClearBasketAsync(userId);
    }
  /*  public async Task<(bool Success, string Message)> AddToCartAsync(string userId, BasketItem item)
    {
        var (isAvailable, price) = await CheckProductAvailabilityAsync(item.ProductId, item.Quantity);//TODO API Request

        if (!isAvailable)
        {
            return (false, "Ürün stokta yok veya istenen miktar mevcut değil.");
        }

        item.Price = price;
        await _basketRepository.AddToBasketAsync(userId, item);
        return (true, "Ürün sepete eklendi.");
    }

    public async Task<(bool Success, string Message)> UpdateCartItemAsync(string userId, BasketItem item)
    {
        var (isAvailable, price) = await CheckProductAvailabilityAsync(item.ProductId, item.Quantity); //TODO API Request

        if (!isAvailable)
        {
            return (false, "İstenen miktar stokta mevcut değil.");
        }

        item.Price = price; // Güncel fiyatı kullan
        await _basketRepository.UpdateBasketItemAsync(userId, item);
        return (true, "Sepet güncellendi.");
    }*/
}