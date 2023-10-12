namespace StackedAPI.Contracts.Products;

public record CreateProductRequest(
    string Name,
    string Description,
    string Manufacturer,
    string Sku,
    decimal Price,
    int QuantityInStock,
    int Category
    );