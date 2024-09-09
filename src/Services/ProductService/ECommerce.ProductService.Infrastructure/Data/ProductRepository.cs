using ECommerce.ProductService.Core.Entities;
using ECommerce.ProductService.Core.Interfaces;
using MongoDB.Driver;

namespace ECommerce.ProductService.Infrastructure.Data;

public class ProductRepository(IMongoDatabase database) : IProductRepository
{
    private readonly IMongoCollection<Product> _products = database.GetCollection<Product>("Products");

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _products.Find(_ => true).ToListAsync();
    }

    public async Task<Product> GetByIdAsync(string id)
    {
        return await _products.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Product>> GetByCategoryAsync(string category)
    {
        return await _products.Find(p => p.Category == category).ToListAsync();
    }

    public async Task<Product> AddAsync(Product product)
    {
        product.CreatedAt = DateTime.UtcNow;
        product.UpdatedAt = DateTime.UtcNow;
        await _products.InsertOneAsync(product);
        return product;
    }

    public async Task UpdateAsync(string id, Product product)
    {
        product.UpdatedAt = DateTime.UtcNow;
        await _products.ReplaceOneAsync(p => p.Id == id, product);
    }

    public async Task DeleteAsync(string id)
    {
        await _products.DeleteOneAsync(p => p.Id == id);
    }

    public async Task<bool> ExistsAsync(string id)
    {
        return await _products.Find(p => p.Id == id).AnyAsync();
    }

    public async Task<long> GetCountAsync()
    {
        return await _products.CountDocumentsAsync(_ => true);
    }

    public async Task<IEnumerable<Product>> GetPaginatedAsync(int pageNumber, int pageSize)
    {
        return await _products.Find(_ => true)
            .Skip((pageNumber - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();
    }
}