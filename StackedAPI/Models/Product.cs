namespace StackedAPI.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Manufacturer { get; set; }
    public string Sku { get; set; }
    public decimal Price { get; set; }
    public int QuantityInStock { get; set; }
    public int Category { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    
}