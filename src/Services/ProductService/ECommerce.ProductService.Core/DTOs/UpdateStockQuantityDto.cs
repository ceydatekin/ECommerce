namespace ECommerce.ProductService.Core.DTOs;

public sealed record UpdateStockQuantityDto
{
    public string Id { get; init; }

    public int StockQuantity { get; init; }
}