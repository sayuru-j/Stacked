namespace StackedAPI.Contracts.Products;

public record UpsertProductRequest(
    string Name,
    string Description,
    decimal Price,
    int QuantityInStock,
    string Category
    );