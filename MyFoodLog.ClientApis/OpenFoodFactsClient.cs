using Microsoft.Extensions.Logging;
using MyFoodLog.ClientApis.Interfaces;
using MyFoodLog.ClientApis.Models.OpenFoodFacts;
using Newtonsoft.Json;

namespace MyFoodLog.ClientApis;

public class OpenFoodFactsClient : IOpenFoodFactsClient
{
    private readonly HttpClient _httpClient;

    private readonly ILogger<OpenFoodFactsClient> _logger;

    private const string UserAgent = "MyFoodLog - Linux - Version 1.0";

    private const string BaseUrl = "https://world.openfoodfacts.org";

    public OpenFoodFactsClient(ILogger<OpenFoodFactsClient> logger)
    {
        _logger = logger;
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);
        _httpClient.DefaultRequestHeaders.Add("accept", "application/json");
    }
    
    /// <inheritdoc />
    public async Task<BarcodeResponse?> GetForBarcode(string barcode, CancellationToken ctx = default)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"{BaseUrl}/api/v2/products/{barcode}", ctx);

        if (response.IsSuccessStatusCode)
        {
            BarcodeResponse? barcodeResponse = JsonConvert.DeserializeObject<BarcodeResponse>(await response.Content.ReadAsStringAsync(ctx));
            _logger.LogDebug("OpenFoodFacts response status: {response}", barcodeResponse?.VerboseStatus);
            return barcodeResponse;

        }

        return default;
    }
}