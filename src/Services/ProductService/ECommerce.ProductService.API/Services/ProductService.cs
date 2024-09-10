using ECommerce.ProductService.Core.DTOs;
using ECommerce.ProductService.Core.Entities;
using ECommerce.ProductService.Core.Interfaces;
using ECommerce.Service;
using MassTransit;

namespace ECommerce.ProductService.API.Services;

public class ProductService(IProductRepository productRepository, IPublishEndpoint publishEndpoint)
    : IProductService
{
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await productRepository.GetAllAsync();
    }

    public async Task<Product> GetProductByIdAsync(string id)
    {
        return await productRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
    {
        return await productRepository.GetByCategoryAsync(category);
    }

    public async Task<Product> CreateProductAsync(ProductCreateDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Description = productDto.Description,
            Price = productDto.Price,
            StockQuantity = productDto.StockQuantity,
            Category = productDto.Category,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        return await productRepository.AddAsync(product);
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        var updateResult = await productRepository.UpdateProductAsync(product);

        return updateResult.ModifiedCount > 0;
    }

    public async Task DeleteProductAsync(string id)
    {
        await productRepository.DeleteAsync(id);
    }

    public async Task<bool> ProductExistsAsync(string id)
    {
        return await productRepository.ExistsAsync(id);
    }

    public async Task<long> GetProductCountAsync()
    {
        return await productRepository.GetCountAsync();
    }

    public async Task<IEnumerable<Product>> GetPaginatedProductsAsync(int pageNumber, int pageSize)
    {
        return await productRepository.GetPaginatedAsync(pageNumber, pageSize);
    }

    public async Task<int?> GetStockQuantityByIdAsync(string id)
    {
        var product = await productRepository.GetByIdStockQuantityAsync(id);

        return product?.StockQuantity;
    }

    public async Task<bool> UpdateStockQuantityAsync(string id, int stockQuantity)
    {
        var updateResult = await productRepository.UpdateStockQuantityAsync(id, stockQuantity);

        if (stockQuantity == 0)
        {
            await CheckStockAndPublishEventAsync(id);
        }

        return updateResult.ModifiedCount > 0;
    }

    private async Task CheckStockAndPublishEventAsync(string productId)
    {
        var @event = new ProductOutOfStockEvent { ProductId = productId, };

        await publishEndpoint.Publish(@event);
    }
}