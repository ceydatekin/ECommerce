using ECommerce.ProductService.Core.Entities;
using ECommerce.ProductService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.ProductService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllProductsAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Product product)
    {
        var createdProduct = await _productService.CreateProductAsync(product);
        return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] Product product)
    {
        if (!await _productService.ProductExistsAsync(id))
            return NotFound();
        await _productService.UpdateProductAsync(id, product);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        if (!await _productService.ProductExistsAsync(id))
            return NotFound();
        await _productService.DeleteProductAsync(id);
        return NoContent();
    }

    [HttpGet("category/{category}")]
    public async Task<IActionResult> GetByCategory(string category)
    {
        var products = await _productService.GetProductsByCategoryAsync(category);
        return Ok(products);
    }

    [HttpGet("count")]
    public async Task<IActionResult> GetCount()
    {
        var count = await _productService.GetProductCountAsync();
        return Ok(count);
    }

    [HttpGet("paged")]
    public async Task<IActionResult> GetPaginated([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var products = await _productService.GetPaginatedProductsAsync(pageNumber, pageSize);
        return Ok(products);
    }
}