namespace StackedAPI.Contracts.Products;

public record UpsertProductRequest(
    string Name,
    string Description,
    string Manufacturer,
    string SKU,
    decimal Price,
    int QuantityInStock,
    int CategoryId
    );