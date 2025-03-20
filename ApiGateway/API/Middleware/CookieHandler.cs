using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class CookieHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        if (request.Headers.TryGetValues("Cookie", out var cookieValues))
        {
            request.Headers.Add("Cookie", cookieValues);
        }
        return await base.SendAsync(request, cancellationToken);
    }
}