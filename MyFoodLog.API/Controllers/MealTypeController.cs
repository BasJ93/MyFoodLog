using Microsoft.AspNetCore.Mvc;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Models.MealTypes;

namespace MyFoodLog.API.Controllers;

/// <summary>
/// Controller to interact with <see cref="MyFoodLog.Database.Models.MealType"/>s.
/// </summary>
[ApiController]
[Route("/api/v1/meal-types")]
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
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>A list of known <see cref="MyFoodLog.Database.Models.MealType"/>s.</returns>
    [HttpGet("")]
    [ProducesResponseType(typeof(IEnumerable<MealTypeDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMealTypes(CancellationToken ctx)
    {
        return new JsonResult(await _mealTypeService.GetAll(ctx));
    }
    
    /// <summary>
    /// Create a new <see cref="MyFoodLog.Database.Models.MealType"/> that can be assigned to meals during the day.
    /// </summary>
    /// <param name="requestDto">The request model.</param>
    /// <param name="ctx">Cancellation token</param>
    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] CreateMealTypeDto requestDto, CancellationToken ctx)
    {
        await _mealTypeService.Create(requestDto, ctx);

        return Ok();
    }
}