using ECommerce.ProductService.Core.DTOs;
using ECommerce.ProductService.Core.Entities;
using ECommerce.ProductService.Core.Interfaces;

namespace ECommerce.ProductService.API.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        return await _productRepository.GetAllAsync();
    }

    public async Task<Product> GetProductByIdAsync(string id)
    {
        return await _productRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category)
    {
        return await _productRepository.GetByCategoryAsync(category);
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

        return await _productRepository.AddAsync(product);
    }

    public async Task<bool> UpdateProductAsync(Product product)
    {
        var updateResult = await _productRepository.UpdateProductAsync(product);
        return updateResult.ModifiedCount > 0;
    }

    public async Task DeleteProductAsync(string id)
    {
        await _productRepository.DeleteAsync(id);
    }

    public async Task<bool> ProductExistsAsync(string id)
    {
        return await _productRepository.ExistsAsync(id);
    }

    public async Task<long> GetProductCountAsync()
    {
        return await _productRepository.GetCountAsync();
    }

    public async Task<IEnumerable<Product>> GetPaginatedProductsAsync(int pageNumber, int pageSize)
    {
        return await _productRepository.GetPaginatedAsync(pageNumber, pageSize);
    }

    public async Task<int?> GetStockQuantityByIdAsync(string id)
    {
        var product = await _productRepository.GetByIdStockQuantityAsync(id);
        return product?.StockQuantity;
    }

    public async Task<bool> UpdateStockQuantityAsync(string id, int stockQuantity)
    {
        var updateResult = await _productRepository.UpdateStockQuantityAsync(id, stockQuantity);
        return updateResult.ModifiedCount > 0;
    }
}