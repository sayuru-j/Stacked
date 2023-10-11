using Microsoft.AspNetCore.Mvc;
using StackedAPI.Contracts.Products;

namespace StackedAPI.Controllers;

[ApiController]
[Route("/products")]
public class ProductController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateProduct(CreateProductRequest request)
    {
        return Ok(request);
    }

    [HttpGet("/{id:guid}")]
    public IActionResult GetProducts(Guid id)
    {
        return Ok(id);
    }

    [HttpPut("/{id:guid}")]
    public IActionResult UpdateProduct(Guid id, UpsertProductRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("/{id:guid}")]
    public IActionResult DeleteProduct(Guid id)
    {
        return Ok();
    }
    
}