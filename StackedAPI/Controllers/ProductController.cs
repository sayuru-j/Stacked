using Microsoft.AspNetCore.Mvc;
using StackedAPI.Contracts.Products;
using StackedAPI.Models;
using StackedAPI.Services.Products;

namespace StackedAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult CreateProduct(CreateProductRequest request)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Manufacturer = request.Manufacturer,
            Sku = request.Sku,
            Price = request.Price,
            QuantityInStock = request.QuantityInStock,
            Category = request.Category,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };

        _productService.CreateProduct(product);

        var response = new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Manufacturer,
            product.Sku,
            product.Price,
            product.QuantityInStock,
            product.Category,
            product.ModifiedAt
        );
        
        return CreatedAtAction(
            actionName: nameof(GetProducts),
            routeValues: new { id = product.Id },
            value: response
            );
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetProducts(Guid id)
    {
        Product? product = _productService.GetProduct(id);

        if (product == null)
        {
            return NotFound();
        }

        var response = new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Manufacturer,
            product.Sku,
            product.Price,
            product.QuantityInStock,
            product.Category,
            product.ModifiedAt
            );
        
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateProduct(Guid id, UpsertProductRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult DeleteProduct(Guid id)
    {
        var response = _productService.DeleteProduct(id);
        return Ok(response);
    }
    
}