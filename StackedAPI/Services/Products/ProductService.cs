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

    public void CreateProduct(Product product)
    {
        // Add the product to the context
        _dbContext.Set<Product>().Add(product);
        
        // Save changes in database
        _dbContext.SaveChanges();
    }

    public Product? GetProduct(Guid guid)
    {
        var product = _dbContext.Set<Product>().FirstOrDefault(p => p.Id == guid);

        return product;
    }

    public Product UpdateProduct(Guid guid, Product request)
    {
        throw new NotImplementedException();
    }

    public bool DeleteProduct(Guid guid)
    {
        var productToDelete = _dbContext.Set<Product>().FirstOrDefault(p => p.Id == guid);
        if (productToDelete == null)
        {
            return false;
        }

        _dbContext.Set<Product>().Remove(productToDelete);
        _dbContext.SaveChanges();

        return true;
    }
}