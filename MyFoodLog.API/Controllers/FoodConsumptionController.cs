using Microsoft.AspNetCore.Mvc;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Models.FoodConsumption;

namespace MyFoodLog.API.Controllers;

/// <summary>
/// API endpoints to manage food consumption.
/// </summary>
[ApiController]
[Route("/api/v1/foodconsumption")]
public sealed class FoodConsumptionController : ControllerBase
{
    private readonly ILogger<FoodConsumptionController> _logger;

    private readonly IFoodConsumptionService _foodConsumptionService;

    public FoodConsumptionController(ILogger<FoodConsumptionController> logger, IFoodConsumptionService foodConsumptionService)
    {
        _logger = logger;
        _foodConsumptionService = foodConsumptionService;
    }

    /// <summary>
    /// Create a new consumption of a <see cref="MyFoodLog.Database.Models.FoodItem"/>.
    /// </summary>
    /// <param name="consumptionDto">Request dto.</param>
    /// <param name="ctx">Cancellation token.</param>
    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] AddConsumptionRequestDto consumptionDto, CancellationToken ctx)
    {
        await _foodConsumptionService.AddConsumption(consumptionDto, ctx);

        return Ok();
    }
    
    /// <summary>
    /// Delete a consumption of a <see cref="MyFoodLog.Database.Models.FoodItem"/> by id.
    /// </summary>
    /// <param name="id">The id of the <see cref="MyFoodLog.Database.Models.FoodItemConsumption"/></param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>200 OK or 404 NotFound.</returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ctx)
    {
        if (await _foodConsumptionService.DeleteConsumption(id, ctx))
        {
            return Ok();
        }

        return NotFound();
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, CancellationToken ctx)
    {
        throw new NotImplementedException();
    }
}