namespace ECommerce.Service;

public interface IProductOutOfStockEvent 
{
    public string ProductId { get; set; }
}