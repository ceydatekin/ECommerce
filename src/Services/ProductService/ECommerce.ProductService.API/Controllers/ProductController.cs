using ECommerce.ProductService.Core.DTOs;
using ECommerce.ProductService.Core.Entities;
using ECommerce.ProductService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.ProductService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await productService.GetAllProductsAsync();

        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var product = await productService.GetProductByIdAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductCreateDto product)
    {
        var createdProduct = await productService.CreateProductAsync(product);

        return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductDto updateDto)
    {
        var product = new Product
        {
            Id = updateDto.Id,
            Name = updateDto.Name,
            Description = updateDto.Description,
            Price = updateDto.Price,
            StockQuantity = updateDto.StockQuantity,
            Category = updateDto.Category,
            UpdatedAt = DateTime.UtcNow
        };

        var result = await productService.UpdateProductAsync(product);

        if (result)
        {
            return NoContent();
        }

        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        if (!await productService.ProductExistsAsync(id))
        {
            return NotFound();
        }

        await productService.DeleteProductAsync(id);

        return NoContent();
    }

    [HttpGet("Category/{category}")]
    public async Task<IActionResult> GetByCategory(string category)
    {
        var products = await productService.GetProductsByCategoryAsync(category);

        return Ok(products);
    }

    [HttpGet("Count")]
    public async Task<IActionResult> GetCount()
    {
        var count = await productService.GetProductCountAsync();

        return Ok(count);
    }

    [HttpGet("Paged")]
    public async Task<IActionResult> GetPaginated([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var products = await productService.GetPaginatedProductsAsync(pageNumber, pageSize);

        return Ok(products);
    }

    [HttpGet("Stock/{id}")]
    public async Task<IActionResult> GetStockQuantity(string id)
    {
        var stockQuantity = await productService.GetStockQuantityByIdAsync(id);

        if (stockQuantity == null)
        {
            return NotFound();
        }

        return Ok(stockQuantity);
    }

    [HttpPut("UpdateStock")]
    public async Task<IActionResult> UpdateStockQuantity([FromBody] UpdateStockQuantityDto updateDto)
    {
        var result = await productService.UpdateStockQuantityAsync(updateDto.Id, updateDto.StockQuantity);

        if (result)
        {
            return NoContent();
        }

        return NotFound();
    }
}