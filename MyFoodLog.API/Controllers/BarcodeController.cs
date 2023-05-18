using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MyFoodLog.ClientApis.Interfaces;
using MyFoodLog.ClientApis.Models.OpenFoodFacts;

namespace MyFoodLog.API.Controllers;

[ApiController]
[Route("/api/{version:apiVersion}/barcode")]
[ApiVersion("1.0")]
public sealed class BarcodeController : Controller
{
    private readonly ILogger<BarcodeController> _logger;
    
    private readonly IOpenFoodFactsClient _openFoodFactsClient;

    /// <summary>
    /// Constructor.
    /// </summary>
    public BarcodeController(IOpenFoodFactsClient openFoodFactsClient, ILogger<BarcodeController> logger)
    {
        _openFoodFactsClient = openFoodFactsClient;
        _logger = logger;
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchForBarcode([FromQuery] string barcode, CancellationToken ctx)
    {
        BarcodeResponse? response = await _openFoodFactsClient.GetForBarcode(barcode, ctx);

        if (response != default)
        {
            return new JsonResult(response.Product);
        }

        return NotFound();
    }
}