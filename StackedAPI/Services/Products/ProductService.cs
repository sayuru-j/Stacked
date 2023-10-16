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

    public IEnumerable<Product> GetProductList()
    {
        var productsList = _dbContext.Set<Product>().ToList();

        return productsList;
    }

    public void UpdateProduct(Guid guid, Product request)
    {
        var existingProduct = _dbContext.Set<Product>().Find(guid);

        if (existingProduct == null)
        {
            throw new Exception("Product not found");
        }

        _dbContext.Set<Product>().Update(request);
        
        try
        {
            _dbContext.SaveChanges();
        }
        catch (DbUpdateException e)
        {
            Console.WriteLine(e);
            throw;
        }
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