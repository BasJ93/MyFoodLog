using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Models.MealTypes;

namespace MyFoodLog.API.Controllers;

/// <summary>
/// Controller to interact with <see cref="MyFoodLog.Database.Models.MealType"/>s.
/// </summary>
[ApiController]
[Route("/api/{version:apiVersion}/meal-types")]
[ApiVersion("1.0")]
public sealed class MealTypeController : ControllerBase
{
    private readonly IMealTypeService _mealTypeService;

    /// <summary>
    /// Constructor.
    /// </summary>
    public MealTypeController(IMealTypeService mealTypeService)
    {
        _mealTypeService = mealTypeService;
    }
    
    /// <summary>
    /// Get the meal types the system knows about.
    /// </summary>
    /// <param name="ctx"><see cref="CancellationToken"/></param>
    /// <returns>A list of known <see cref="MyFoodLog.Database.Models.MealType"/>s.</returns>
    [HttpGet("")]
    [ProducesResponseType(typeof(IEnumerable<MealTypeDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMealTypes(CancellationToken ctx = default)
    {
        return new JsonResult(await _mealTypeService.GetAll(ctx));
    }
    
    /// <summary>
    /// Create a new <see cref="MyFoodLog.Database.Models.MealType"/> that can be assigned to meals during the day.
    /// </summary>
    /// <param name="requestDto">The request model.</param>
    /// <param name="ctx"><see cref="CancellationToken"/></param>
    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] CreateMealTypeDto requestDto, CancellationToken ctx = default)
    {
        // TODO: Return the created object

        MealTypeDto createdMealType = await _mealTypeService.Create(requestDto, ctx);

        return Created($"{Request.Path.Value}/{createdMealType.Id}", createdMealType);
    }

    /// <summary>
    /// Update an existing <see cref="MyFoodLog.Database.Models.MealType"/>.
    /// </summary>
    /// <param name="id">The id of the <see cref="MyFoodLog.Database.Models.MealType"/>.</param>
    /// <param name="ctx"><see cref="CancellationToken"/></param>
    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] MealTypeDto updateDto, CancellationToken ctx = default)
    {
        if (await _mealTypeService.Update(id, updateDto, ctx) != null)
        {
            return Ok();
        }
        
        return NotFound();
    }
    
    /// <summary>
    /// Remove an existing <see cref="MyFoodLog.Database.Models.MealType"/>.
    /// </summary>
    /// <param name="id">The id of the <see cref="MyFoodLog.Database.Models.MealType"/>.</param>
    /// <param name="ctx"><see cref="CancellationToken"/></param>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken ctx = default)
    {
        if (await _mealTypeService.Delete(id, ctx))
        {
            return Ok();
        }
        
        return NotFound();
    }
}