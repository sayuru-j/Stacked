using Microsoft.AspNetCore.Mvc;
using StackedAPI.DummyData;
using StackedAPI.Models.Dto;

namespace StackedAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    [HttpGet]
    public IEnumerable<ItemDto> GetItems()
    {
        return ItemStore.itemList;
    }

    [HttpGet("id")]
    public ItemDto GetItem(int id)
    {
        return ItemStore.itemList.FirstOrDefault(u => u.Id == id);
    }
}