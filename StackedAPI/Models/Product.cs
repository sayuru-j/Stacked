using System.ComponentModel.DataAnnotations;

namespace StackedAPI.Models;

public class Product
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Product name is required.")]
    [MaxLength(100, ErrorMessage = "Product name cannot exceed 100 characters.")]
    [Display(Name = "Product Name")]
    public string Name { get; set; }

    [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
    public string Description { get; set; }

    [MaxLength(100, ErrorMessage = "Manufacturer name cannot exceed 100 characters.")]
    public string Manufacturer { get; set; }

    [Required(ErrorMessage = "SKU is required.")]
    [MaxLength(20, ErrorMessage = "SKU cannot exceed 20 characters.")]
    public string SKU { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Price must be non-negative.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Quantity in stock is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be non-negative.")]
    [Display(Name = "Quantity in Stock")]
    public int QuantityInStock { get; set; }

    [Required(ErrorMessage = "Category ID is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "Category ID must be a positive integer.")]
    [Display(Name = "Category ID")]
    public int CategoryId { get; set; }

    [Display(Name = "Created At")]
    public DateTime CreatedAt { get; set; }

    [Display(Name = "Modified At")]
    public DateTime ModifiedAt { get; set; }
    
}