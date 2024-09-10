﻿using ECommerce.BasketService.Core.Entities;

namespace ECommerce.BasketService.Core.Interfaces;

public interface IBasketService
{
    Task<Basket> GetBasketAsync(string userId);
    
    Task RemoveFromBasketAsync(string userId, string productId);

    Task ClearBasketAsync(string userId);
    
    Task<(bool Success, string Message)> AddToBasketItemAsync(string userId, BasketItem item);

    Task<(bool Success, string Message)> UpdateBasketAsync(string userId, BasketItem item);
}