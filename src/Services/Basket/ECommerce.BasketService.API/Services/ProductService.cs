using ECommerce.BasketService.Core.DTOs;
using ECommerce.BasketService.Core.Interfaces;

namespace ECommerce.BasketService.API.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("ProductApiClient");
    }
    
    public async Task<(bool IsAvailable, decimal Price)> CheckProductAvailabilityAsync(string productId, int quantity)
    {
        var response = await _httpClient.GetAsync($"api/products/{productId}/availability?quantity={quantity}");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync<ProductAvailabilityDto>();
            return (result.IsAvailable, result.Price);
        }
        return (false, 0);
    }
}