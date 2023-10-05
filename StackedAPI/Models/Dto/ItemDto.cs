using System.ComponentModel.DataAnnotations;

namespace StackedAPI.Models.Dto;

public class ItemDto
{
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
}