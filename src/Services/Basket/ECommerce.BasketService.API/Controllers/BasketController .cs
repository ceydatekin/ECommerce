using ECommerce.BasketService.Core.Entities;
using ECommerce.BasketService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.BasketService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BasketController : ControllerBase
{
    private readonly IBasketService _basketService;

    public BasketController(IBasketService basketService)
    {
        _basketService = basketService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetCart(string userId)
    {
        var cart = await _basketService.GetBasketAsync(userId);

        return Ok(cart);
    }

    [HttpPost("{userId}/items")]
    public async Task<IActionResult> AddToCart(string userId, [FromBody] BasketItem item)
    {
        await _basketService.AddToBasketAsync(userId, item);

        return Ok();
    }

    [HttpPut("{userId}/items")]
    public async Task<IActionResult> UpdateCartItem(string userId, [FromBody] BasketItem item)
    {
        await _basketService.UpdateBasketItemAsync(userId, item);

        return Ok();
    }

    [HttpDelete("{userId}/items/{productId}")]
    public async Task<IActionResult> RemoveFromCart(string userId, string productId)
    {
        await _basketService.RemoveFromBasketAsync(userId, productId);

        return Ok();
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> ClearCart(string userId)
    {
        await _basketService.ClearBasketAsync(userId);

        return Ok();
    }
}