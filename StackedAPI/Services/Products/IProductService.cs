using StackedAPI.Contracts.Products;
using StackedAPI.Models;

namespace StackedAPI.Services.Products;

public interface IProductService
{
    public void CreateProduct(Product product);
    public Product? GetProduct(Guid guid);
    public Product UpdateProduct(Guid guid, Product request);
    public bool DeleteProduct(Guid guid);
}