namespace StackedAPI.Contracts.Products;

public record UpsertProductRequest(
    string Name,
    string Description,
    string Manufacturer,
    string Sku,
    decimal Price,
    int QuantityInStock,
    string Category
    );