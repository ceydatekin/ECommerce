using ECommerce.ProductService.Core.Entities;

namespace ECommerce.ProductService.Core.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(string id);
    Task<IEnumerable<Product>> GetByCategoryAsync(string category);
    Task<Product> AddAsync(Product product);
    Task UpdateAsync(string id, Product product);
    Task DeleteAsync(string id);
    Task<bool> ExistsAsync(string id);
    Task<long> GetCountAsync();
    Task<IEnumerable<Product>> GetPaginatedAsync(int pageNumber, int pageSize);
}