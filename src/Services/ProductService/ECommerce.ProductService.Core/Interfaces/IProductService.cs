using ECommerce.ProductService.Core.Entities;

namespace ECommerce.ProductService.Core.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(string id);
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(string category);
    Task<Product> CreateProductAsync(Product product);
    Task UpdateProductAsync(string id, Product product);
    Task DeleteProductAsync(string id);
    Task<bool> ProductExistsAsync(string id);
    Task<long> GetProductCountAsync();
    Task<IEnumerable<Product>> GetPaginatedProductsAsync(int pageNumber, int pageSize);
}