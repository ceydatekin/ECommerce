namespace ECommerce.BasketService.Core.DTOs;

public sealed record AddBasketItemDto
{
    public string ProductId { get; init; }

    public string ProductName { get; init; }

    public decimal Price { get; init; }

    public int Quantity { get; init; }
}