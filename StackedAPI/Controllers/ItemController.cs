using Microsoft.AspNetCore.Mvc;
using StackedAPI.DummyData;
using StackedAPI.Models.Dto;

namespace StackedAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    // Get all the items 
    [HttpGet]
    public ActionResult<IEnumerable<ItemDto>> GetItems()
    {
        return Ok(ItemStore.itemList);
    }

    
    // Gets an item by Id
    [HttpGet("{id:int}", Name = "GetItem")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ItemDto> GetItem(int id)
    {
        if (id == 0)
        {
            return BadRequest();
        }

        var item = ItemStore.itemList.FirstOrDefault(u => u.Id == id);
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);

    }

    // Add an item
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<ItemDto> AddItem([FromBody] ItemDto itemDto)
    {
        if (ItemStore.itemList.FirstOrDefault(u => u.Name.ToLower() == itemDto.Name.ToLower()) != null)
        {
            ModelState.AddModelError("NameUniqueError", "Item Name should be unique");
            return BadRequest(ModelState);
        }
        
        if (itemDto == null)
        {
            return BadRequest(itemDto);
        }

        if (itemDto.Id > 0)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        itemDto.Id = ItemStore.itemList.OrderByDescending(u => u.Id).FirstOrDefault().Id + 1;
        ItemStore.itemList.Add(itemDto);
        
        return CreatedAtRoute("GetItem", new { id = itemDto.Id}, itemDto);
    }
    
}