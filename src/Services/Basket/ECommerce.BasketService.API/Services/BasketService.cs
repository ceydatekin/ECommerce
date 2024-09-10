using ECommerce.BasketService.Core.DTOs;
using ECommerce.BasketService.Core.Entities;
using ECommerce.BasketService.Core.Interfaces;

namespace ECommerce.BasketService.API.Services;

public class BasketService(IBasketRepository basketRepository, IProductService productService)
    : IBasketService
{
    public async Task<Basket> GetBasketAsync(string userId)
    {
        return await basketRepository.GetBasketAsync(userId);
    }

    public async Task RemoveFromBasketAsync(string userId, string productId)
    {
        await basketRepository.RemoveFromBasketAsync(userId, productId);
    }

    public async Task ClearBasketAsync(string userId)
    {
        await basketRepository.ClearBasketAsync(userId);
    }

    public async Task<(bool Success, string Message)> AddToBasketItemAsync(string userId, AddBasketItemDto itemDto)
    {
        var item = new BasketItem()
        {
            ProductId = itemDto.ProductId,
            ProductName = itemDto.ProductName,
            Price = itemDto.Price,
            Quantity = itemDto.Quantity
        };
        var (isAvailable, price) =
            await productService.CheckProductAvailabilityAsync(item.ProductId, item.Quantity);

        if (!isAvailable)
        {
            return (false, "Ürün stokta yok veya istenen miktar mevcut değil.");
        }

        await basketRepository.SetBasketExpirationAsync(userId, TimeSpan.FromMinutes(30));
        item.Price = price;
        await basketRepository.AddToBasketAsync(userId, item);
        return (true, "Ürün sepete eklendi.");
    }

    public async Task<(bool Success, string Message)> UpdateBasketAsync(string userId, BasketItem item)
    {
        var (isAvailable, price) =
            await productService.CheckProductAvailabilityAsync(item.ProductId, item.Quantity);

        if (!isAvailable)
        {
            return (false, "İstenen miktar stokta mevcut değil.");
        }

        await basketRepository.SetBasketExpirationAsync(userId, TimeSpan.FromMinutes(30));
        item.Price = price;
        await basketRepository.UpdateBasketItemAsync(userId, item);
        return (true, "Sepet güncellendi.");
    }

    public async Task RemoveProductFromAllCartsAsync(string productId)
    {
        var carts = await basketRepository.GetAllBasketsAsync();

        foreach (var cart in carts)
        {
            if (cart.Items != null)
            {
                var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);
                if (cartItem != null)
                {
                    cart.Items.Remove(cartItem);
                    await basketRepository.UpdateBasketAsync(cart);
                    Console.WriteLine($"Removed product {productId} from cart {cart.UserId}");
                }
            }
            else
            {
                Console.WriteLine($"Cart {cart.UserId} has null Items");
            }
        }
    }
}