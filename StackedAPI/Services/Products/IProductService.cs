using StackedAPI.Models;

namespace StackedAPI.Services.Products;

public interface IProductService
{
    public void CreateProduct(Product product);
    public Product? GetProduct(Guid guid);
    public IEnumerable<Product> GetProductList();
    public void UpdateProduct(Guid guid, Product request);
    public bool DeleteProduct(Guid guid);
}