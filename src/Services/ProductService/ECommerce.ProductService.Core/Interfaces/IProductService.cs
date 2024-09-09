using ECommerce.ProductService.Core.DTOs;
using ECommerce.ProductService.Core.Entities;

namespace ECommerce.ProductService.Core.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();

    Task<Product> GetProductByIdAsync(string id);

    Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category);

    Task<Product> CreateProductAsync(ProductCreateDto product);

    Task<bool> UpdateProductAsync(Product product);
    Task DeleteProductAsync(string id);

    Task<bool> ProductExistsAsync(string id);

    Task<long> GetProductCountAsync();

    Task<IEnumerable<Product>> GetPaginatedProductsAsync(int pageNumber, int pageSize);

    Task<int?> GetStockQuantityByIdAsync(string id);

    Task<bool> UpdateStockQuantityAsync(string id, int stockQuantity);
}