using Microsoft.AspNetCore.Mvc;
using MyFoodLog.Models;
using MyFoodLog.Core.Services.Interfaces;
using MyFoodLog.Models.FoodConsumption;

namespace MyFoodLog.API.Controllers;

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

    [HttpPost("create")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Create([FromBody] AddConsumptionRequestDto consumptionDto, CancellationToken ctx)
    {
        await _foodConsumptionService.AddConsumption(consumptionDto, ctx);

        return Ok();
    }
    
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromBody] DeleteFoodConsumptionRequestDto request, CancellationToken ctx)
    {
        if (await _foodConsumptionService.DeleteConsumption(request.Id, ctx))
        {
            return Ok();
        }

        return NotFound();
    }

    [HttpPatch("update")]
    public async Task<IActionResult> Update(CancellationToken ctx)
    {
        throw new NotImplementedException();
    }
}