namespace StackedAPI.Contracts.Products;

public record ProductResponse(
    Guid Id,
    string Name,
    string Description,
    decimal Price,
    int QuantityInStock,
    string Category,
    DateTime LastModifiedAt
    );