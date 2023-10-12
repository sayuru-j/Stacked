namespace StackedAPI.Contracts.Products;

public record ProductResponse(
    Guid Id,
    string Name,
    string Description,
    string Manufacturer,
    string Sku,
    decimal Price,
    int QuantityInStock,
    int Category,
    DateTime LastModifiedAt
    );