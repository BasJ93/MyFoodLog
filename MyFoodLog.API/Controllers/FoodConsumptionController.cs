using Microsoft.AspNetCore.Mvc;
using MyFoodLog.Core.Models;
using MyFoodLog.Core.Models.FoodConsumption;
using MyFoodLog.Core.Services.Interfaces;

namespace MyFoodLog.API.Controllers;

[ApiController]
[Route("/api/v1/foodconsumption")]
public class FoodConsumptionController : ControllerBase
{
    private readonly ILogger<FoodConsumptionController> _logger;

    private readonly IFoodConsumptionService _foodConsumptionService;

    public FoodConsumptionController(ILogger<FoodConsumptionController> logger, IFoodConsumptionService foodConsumptionService)
    {
        _logger = logger;
        _foodConsumptionService = foodConsumptionService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] AddConsumptionRequestDto consumptionDto, CancellationToken ctx)
    {
        await _foodConsumptionService.AddConsumption(consumptionDto, ctx);

        return Ok();
    }
    
    [HttpPost("delete")]
    public async Task<IActionResult> Delete(CancellationToken ctx)
    {
        throw new NotImplementedException();
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update(CancellationToken ctx)
    {
        throw new NotImplementedException();
    }
}