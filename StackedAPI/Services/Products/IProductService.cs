using StackedAPI.Contracts.Products;
using StackedAPI.Models;

namespace StackedAPI.Services.Products;

public interface IProductService
{
    public ProductResponse CreateProduct(Product product);
}