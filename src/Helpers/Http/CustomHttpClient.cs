namespace YahooScraper.Helpers.Http;

class CustomHttpClient : HttpClient
{
    public CustomHttpClient(HttpMessageHandler handler) : base(handler)
    {
        Timeout = TimeSpan.FromSeconds(10);
    }
}