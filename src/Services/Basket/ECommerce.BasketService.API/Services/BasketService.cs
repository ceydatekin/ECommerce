using ECommerce.BasketService.Core.Entities;
using ECommerce.BasketService.Core.Interfaces;

namespace ECommerce.BasketService.API.Services;

public class BasketService : IBasketService
{
    private readonly IBasketRepository _basketRepository;
    private readonly IProductService _productService;

    public BasketService(IBasketRepository basketRepository, IProductService productService)
    {
        _basketRepository = basketRepository;
        _productService = productService;
    }

    public async Task<Basket> GetBasketAsync(string userId)
    {
        return await _basketRepository.GetBasketAsync(userId);
    }

    public async Task RemoveFromBasketAsync(string userId, string productId)
    {
        await _basketRepository.RemoveFromBasketAsync(userId, productId);
    }

    public async Task ClearBasketAsync(string userId)
    {
        await _basketRepository.ClearBasketAsync(userId);
    }

    public async Task<(bool Success, string Message)> AddToBasketItemAsync(string userId, BasketItem item)
    {
        var (isAvailable, price) =
            await _productService.CheckProductAvailabilityAsync(item.ProductId, item.Quantity);

        if (!isAvailable)
        {
            return (false, "Ürün stokta yok veya istenen miktar mevcut değil.");
        }

        item.Price = price;
        await _basketRepository.AddToBasketAsync(userId, item);
        return (true, "Ürün sepete eklendi.");
    }

    public async Task<(bool Success, string Message)> UpdateBasketAsync(string userId, BasketItem item)
    {
        var (isAvailable, price) =
            await _productService.CheckProductAvailabilityAsync(item.ProductId, item.Quantity); 

        if (!isAvailable)
        {
            return (false, "İstenen miktar stokta mevcut değil.");
        }

        item.Price = price; 
        await _basketRepository.UpdateBasketItemAsync(userId, item);
        return (true, "Sepet güncellendi.");
    }
}