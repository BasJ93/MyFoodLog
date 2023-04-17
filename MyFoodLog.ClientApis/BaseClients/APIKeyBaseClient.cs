namespace MyFoodLog.ClientApis.BaseClients;

public partial class APIKeyBaseClient
{
    protected async Task<HttpClient> CreateHttpClientAsync(CancellationToken cancellationToken)
    {
        var client = new HttpClient();
        // TODO: Customize HTTP client
        return client; 
    }
}