using Microsoft.AspNetCore.Mvc;
using MyFoodLog.Core.Models.FoodConsumption;
using MyFoodLog.Core.Models.FoodItem;
using MyFoodLog.Core.Services.Interfaces;

namespace MyFoodLog.API.Controllers;

[ApiController]
[Route("/api/v1/fooditem")]
public class FoodItemController : ControllerBase
{
    private readonly IFoodItemService _foodItems;

    public FoodItemController(IFoodItemService foodItems)
    {
        _foodItems = foodItems;
    }

    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateFoodItem([FromBody] CreateFoodItemDto dto, CancellationToken ctx)
    {
        await _foodItems.Create(dto, ctx);

        return Ok();
    }
    
    [HttpGet("search")]
    [ProducesResponseType(typeof(List<FoodItemDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Search([FromQuery] SearchFoodDto searchDto, CancellationToken ctx)
    {
        ICollection<FoodItemDto> items = await _foodItems.Search(searchDto, ctx);

        if (items.Any())
        {
            return new JsonResult(items);
        }
        
        // If there is no result, ask the user to enter the data for the product themselves.
        return NotFound();
    }
}