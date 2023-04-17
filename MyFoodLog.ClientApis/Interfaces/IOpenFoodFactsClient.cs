using MyFoodLog.ClientApis.Models.OpenFoodFacts;

namespace MyFoodLog.ClientApis.Interfaces;

public interface IOpenFoodFactsClient
{
    /// <summary>
    /// Get nutritional information from OpenFoodFacts for a given barcode.
    /// </summary>
    /// <param name="barcode">The barcode to request the data for.</param>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>The nutritional information if available.</returns>
    Task<BarcodeResponse?> GetForBarcode(string barcode, CancellationToken ctx = default);
}