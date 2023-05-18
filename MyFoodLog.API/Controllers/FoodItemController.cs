using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MyFoodLog.Models.FoodConsumption;
using MyFoodLog.Models.FoodItem;
using MyFoodLog.Core.Services.Interfaces;

namespace MyFoodLog.API.Controllers;

/// <summary>
/// Controller to interact with <see cref="MyFoodLog.Database.Models.FoodItem"/>s.
/// </summary>
[ApiController]
[Route("/api/{version:apiVersion}/food-items")]
[ApiVersion("1.0")]
public sealed class FoodItemController : ControllerBase
{
    private readonly IFoodItemService _foodItems;

    /// <summary>
    /// Constructor.
    /// </summary>
    public FoodItemController(IFoodItemService foodItems)
    {
        _foodItems = foodItems;
    }

    /// <summary>
    /// Get all known <see cref="MyFoodLog.Database.Models.FoodItem"/>s.
    /// </summary>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The collection of known food items.</returns>
    [HttpGet("")]
    [ProducesResponseType(typeof(ICollection<FoodItemDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken ctx)
    {
        return new JsonResult(await _foodItems.All(ctx));
    }
    
    /// <summary>
    /// Create a new <see cref="MyFoodLog.Database.Models.FoodItem"/>.
    /// </summary>
    /// <param name="dto">The food item to create.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>Returns the created food item.</returns>
    [HttpPost("")]
    [ProducesResponseType(typeof(FoodItemDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateFoodItem([FromBody] CreateFoodItemDto dto, CancellationToken ctx)
    {
        FoodItemDto result = await _foodItems.Create(dto, ctx);

        return new JsonResult(result);
    }

    /// <summary>
    /// Delete a <see cref="MyFoodLog.Database.Models.FoodItem"/> by id.
    /// </summary>
    /// <param name="id">The id of the food item.</param>
    /// <param name="ctx">Cancellation token.</param>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteFoodItem(Guid id, CancellationToken ctx)
    {
        await _foodItems.Delete(id, ctx);

        return Ok();
    }
    
    /// <summary>
    /// Get a food item by its Id.
    /// </summary>
    /// <param name="id">The id of the food item.</param>
    /// <param name="ctx">Cancellation token.</param>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(FoodItemDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFoodItem(Guid id, CancellationToken ctx)
    {
        return new JsonResult(await _foodItems.ById(id, ctx));
    }
    
    /// <summary>
    /// Update a food item.
    /// </summary>
    /// <param name="id">The id of the item to update.</param>
    /// <param name="dto">The new values for the item.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The updated item.</returns>
    [HttpPatch("{id:guid}")]
    [ProducesResponseType(typeof(FoodItemDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateFoodItem(Guid id, [FromBody] CreateFoodItemDto dto, CancellationToken ctx)
    {
        FoodItemDto? result = await _foodItems.Update(id, dto, ctx);

        if (result == null)
        {
            return Ok();
        }

        return new JsonResult(result);
    }
    
    /// <summary>
    /// Search for a food item by name or by barcode.
    /// </summary>
    /// <param name="searchDto">The search target.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>A list of items that match the search input.</returns>
    [HttpGet("search")]
    [ProducesResponseType(typeof(List<FoodItemDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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