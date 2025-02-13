using System.Diagnostics;

namespace YahooScraper.Helpers.Http;

class CustomHttpHandler : DelegatingHandler
{
    public CustomHttpHandler() : base(new HttpClientHandler())
    {
    }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                                 CancellationToken cancellationToken)
    {


        request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:134.0) Gecko/20100101 Firefox/134.0");

        Debug.WriteLine(request.ToCurlRequest());

        return await base.SendAsync(request, cancellationToken);
    }
}