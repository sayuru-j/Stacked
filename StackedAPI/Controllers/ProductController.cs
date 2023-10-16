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
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult CreateProduct(CreateProductRequest request)
    {
        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            Manufacturer = request.Manufacturer,
            SKU = request.SKU,
            Price = request.Price,
            QuantityInStock = request.QuantityInStock,
            CategoryId = request.CategoryId,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow
        };

        _productService.CreateProduct(product);

        var response = new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Manufacturer,
            product.SKU,
            product.Price,
            product.QuantityInStock,
            product.CategoryId,
            product.ModifiedAt
        );
        
        return CreatedAtAction(
            actionName: nameof(GetProducts),
            routeValues: new { id = product.Id },
            value: response
            );
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetProductList()
    {
        var products = _productService.GetProductList();

        var productList = products as Product[] ?? products.ToArray();
        
        if (!productList.Any())
        {
            return NoContent();
        }

        return Ok(new { Products = productList,  TotalCount = productList.Length});
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetProducts(Guid id)
    {
        var product = _productService.GetProduct(id);

        if (product == null)
        {
            return NotFound();
        }

        var response = new ProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Manufacturer,
            product.SKU,
            product.Price,
            product.QuantityInStock,
            product.CategoryId,
            product.ModifiedAt
            );
        
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateProduct(Guid id, UpsertProductRequest request)
    {
        var existingProduct = _productService.GetProduct(id);
        if (existingProduct == null)
        {
            return NotFound();
        }

        existingProduct.Name = request.Name;
        existingProduct.Description = request.Description;
        existingProduct.Manufacturer = request.Manufacturer;
        existingProduct.SKU = request.SKU;
        existingProduct.Price = request.Price;
        existingProduct.QuantityInStock = request.QuantityInStock;
        existingProduct.CategoryId = request.CategoryId;
        
        _productService.UpdateProduct(id, existingProduct);
        
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteProduct(Guid id)
    {
        var isDeleted = _productService.DeleteProduct(id);
        if (isDeleted == false)
        {
            return NotFound();
        }

        return Ok();
    }
    
}