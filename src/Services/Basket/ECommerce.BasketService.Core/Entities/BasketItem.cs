namespace ECommerce.BasketService.Core.Entities;

public class BasketItem
{
    public string ProductId { get; set; }

    public string ProductName { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }
}