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

    public async Task<Product> CreateProductAsync(Product product)
    {
        // Burada ürün doğrulama işlemleri yapılabilir
        return await _productRepository.AddAsync(product);
    }

    public async Task UpdateProductAsync(string id, Product product)
    {
        // Burada ürün doğrulama işlemleri yapılabilir
        await _productRepository.UpdateAsync(id, product);
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
}