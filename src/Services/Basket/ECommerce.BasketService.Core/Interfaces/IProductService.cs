namespace ECommerce.BasketService.Core.Interfaces;

public interface IProductService
{
    Task<(bool IsAvailable, decimal Price)> CheckProductAvailabilityAsync(string productId, int quantity);
}