using Microsoft.EntityFrameworkCore;
using StackedAPI.Contracts.Products;
using StackedAPI.Data;
using StackedAPI.Models;

namespace StackedAPI.Services.Products;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _dbContext;


    public ProductService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ProductResponse CreateProduct(Product product)
    {
        // Add the product to the context
        _dbContext.Set<Product>().Add(product);
        
        // Save changes in database
        _dbContext.SaveChanges();
    
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
        
        return response;
    }
}