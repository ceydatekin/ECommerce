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

    [HttpPost("{userId}/Items")]
    public async Task<IActionResult> AddToBasket(string userId, [FromBody] BasketItem item)
    {
        var (success, message) = await _basketService.AddToBasketItemAsync(userId, item);
        if (success)
        {
            return Ok(message);
        }

        return BadRequest(message);
    }

    [HttpPut("{userId}/Items")]
    public async Task<IActionResult> UpdateBasket(string userId, [FromBody] BasketItem item)
    {
        var (success, message) = await _basketService.UpdateBasketAsync(userId, item);
        if (success)
        {
            return Ok(message);
        }

        return BadRequest(message);
    }
}