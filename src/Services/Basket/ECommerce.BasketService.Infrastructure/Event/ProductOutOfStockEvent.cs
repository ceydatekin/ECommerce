namespace ECommerce.Service;

public class ProductOutOfStockEvent : IProductOutOfStockEvent
{
    public string ProductId { get; set; }
}