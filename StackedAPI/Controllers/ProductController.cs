using Microsoft.AspNetCore.Mvc;
using StackedAPI.Logging;

namespace StackedAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly ILogging _logger;

    public ProductController(ILogging logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public IActionResult GetProduct()
    {
        _logger.Log("Works", "success");
        return Ok();
    }
}