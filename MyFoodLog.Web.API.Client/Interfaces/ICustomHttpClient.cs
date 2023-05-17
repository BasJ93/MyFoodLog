namespace MyFoodLog.Web.API.Client.Interfaces;

public interface ICustomHttpClient : IDisposable
{
    Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption responseHeadersRead, CancellationToken cancellationToken);
}