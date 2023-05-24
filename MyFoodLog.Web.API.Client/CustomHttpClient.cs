using Microsoft.Extensions.Configuration;
using MyFoodLog.Web.API.Client.Interfaces;

namespace MyFoodLog.Web.API.Client;

public sealed class CustomHttpClient : HttpClient, ICustomHttpClient
{
    public CustomHttpClient(IConfiguration configuration)
    {
        try
        {
            BaseAddress = new (configuration["baseUrl"] ?? string.Empty);
        }
        catch (Exception)
        {
            BaseAddress = new(string.Empty);
        }
    }
}