namespace ECommerce.ProductService.Core.DTOs;

public sealed record ProductCreateDto
{
    public string Name { get; init; }

    public string Description { get; init; }

    public decimal Price { get; init; }

    public int StockQuantity { get; init; }

    public string Category { get; init; }
}