using HtmlAgilityPack;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using YahooScraper.Helpers;
using YahooScraper.Helpers.Http;
using YahooScraper.Interfaces.Api;
using YahooScraper.Models.Api;
using YahooScraper.Models.Domain;

namespace YahooScraper.Implementation.Api;

internal class YahooFinanceService(CustomHttpClient client) : IYahooFinanceService
{
    public async Task<CompanyInfo> GetCompanyInfo(string searchData)
    {
        var result = await client.GetAsync($"https://finance.yahoo.com/quote/{searchData}/profile/");

        if (!result.IsSuccessStatusCode) return default!;
        
        var response = await result.Content.ReadAsStringAsync();

        var htmlDoc = new HtmlDocument();
        htmlDoc.LoadHtml(response);
        var scriptNode = htmlDoc.DocumentNode.SelectSingleNode("//script[@type='application/json' and starts-with(@data-url, 'https://query1.finance.yahoo.com/v10/finance/quoteSummary/')]").InnerHtml;
        
        if (scriptNode == null) return default!;
        
        var responseObject = JsonConvert.DeserializeObject<ScriptResponse>(scriptNode);
        if (responseObject?.Body == null || responseObject.StatusText?.ToLower() != "ok")
            return default!;
        
        var companyInfo = JsonConvert.DeserializeObject<YahooCompanyInfoDto>(responseObject.Body);

        return companyInfo != null ? new CompanyInfo(companyInfo) : default!;
    }

    public async Task<CompanyPriceInfo?> GetTickerOnSelectedDate(CompanyInfo company, DateTime startDate)
    {
        var result = await client.GetAsync($"https://query1.finance.yahoo.com/v8/finance/chart/{company.Symbol}?period1={startDate.ToUnixTime()}&period2={startDate.AddDays(1).ToUnixTime()}&interval=5m&includePre");

        if (!result.IsSuccessStatusCode) return null;
        
        var response = await result.Content.ReadAsStringAsync();
        
        var companyPriceInfo = JsonConvert.DeserializeObject<YahooCompanyPriceInfoDto>(response);
        
        return companyPriceInfo == null ? null : new CompanyPriceInfo(company.Id, companyPriceInfo, startDate);
    }

    public async Task<ObservableCollection<QuoteItem>> GetTickers(string searchData)
    {
        var items = new ObservableCollection<QuoteItem>();
        var result = await client.GetAsync($"https://query2.finance.yahoo.com/v1/finance/search?q={searchData}&lang=en-US&region=US&quotesCount=7&quotesQueryId=tss_match_phrase_query&multiQuoteQueryId=multi_quote_single_token_query&enableCb=false&enableNavLinks=true&enableCulturalAssets=true&enableNews=false&enableResearchReports=false&enableLists=false&listsCount=2&recommendCount=6");

        if (!result.IsSuccessStatusCode) return items;
        
        var response = await result.Content.ReadAsStringAsync();
        var responseObject = JsonConvert.DeserializeObject<SearchResponse>(response);

        if (responseObject == null) return items;
        
        foreach (var item in responseObject.Quotes ?? [])
        {
            items.Add(new QuoteItem(item));
        }
        return items;
    }
}
