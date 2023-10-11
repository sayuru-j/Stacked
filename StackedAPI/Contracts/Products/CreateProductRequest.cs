namespace StackedAPI.Contracts.Products;

public record CreateProductRequest(
    string Name,
    string Description,
    decimal Price,
    int QuantityInStock,
    string Category
    );