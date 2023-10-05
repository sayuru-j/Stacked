namespace StackedAPI.Models;

public class Product
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    // SKU -> Stock Keeping Unit
    public string SKU { get; set; }
    
    public string Manufacturer { get; set; }
    
    public decimal Price { get; set; }
    
    public int QuantityInStock { get; set; }
    
    public string Category { get; set; }
    
    // Change this data type as Supplier after Supplier Model has been created.
    public string Supplier { get; set; }
    
    public DateTime DateAdded { get; set; }
}