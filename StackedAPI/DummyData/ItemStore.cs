using StackedAPI.Models.Dto;

namespace StackedAPI.DummyData;

public class ItemStore
{
    public static List<ItemDto> itemList = new List<ItemDto>
    {
        new ItemDto { Id = 1, Name = "Headphones" },
        new ItemDto { Id = 2, Name = "Monitors" }
    };
}