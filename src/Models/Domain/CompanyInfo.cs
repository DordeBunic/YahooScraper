using CommunityToolkit.Mvvm.ComponentModel;
using YahooScraper.Models.Api;
using YahooScraper.Models.Db;

namespace YahooScraper.Models.Domain;

public partial class CompanyInfo : ObservableObject
{
    public CompanyInfo()
    {
            
    }
    public CompanyInfo(YahooCompanyInfoDto companyInfo)
    {
        var myInfo = companyInfo.QuoteSummary?.Result?.FirstOrDefault();
        if (myInfo != null)
        {
            Id = Guid.NewGuid();
            Symbol = myInfo.Price?.Symbol;
            CompanyName = myInfo.Price?.LongName;
            MarketCap = myInfo.Price?.MarketCap?.Fmt;
            NumberOfEmployees = myInfo.AssetProfile?.FullTimeEmployees ?? 0;
            City = myInfo.AssetProfile?.City;
            State = myInfo.AssetProfile?.State;

            var summery = myInfo.AssetProfile?.LongBusinessSummary?.Split(". ");
            var lastSentence = summery?.LastOrDefault();
            if (lastSentence == null) return;
            
            var index = lastSentence.IndexOf("was founded in ", StringComparison.CurrentCultureIgnoreCase);
            if(index != -1)
            {
                YearFounded = lastSentence.Substring(index + 15, 4);
            }
            else
            {
                index = lastSentence.IndexOf("was incorporated in ", StringComparison.CurrentCultureIgnoreCase);
                if (index != -1)
                {
                    YearFounded = lastSentence.Substring(index + 20, 4);
                }

            }
        }
    }

    public CompanyInfo(CompanyInfoDto companyInfo, CompanyPriceInfo? priceInfo = null)
    {
        Id = companyInfo.Id;
        Symbol = companyInfo.Symbol;
        CompanyName = companyInfo.CompanyName;
        MarketCap = companyInfo.MarketCap;
        YearFounded = companyInfo.YearFounded;
        NumberOfEmployees = companyInfo.NumberOfEmployees;
        City = companyInfo.City;
        State = companyInfo.State;
        PriceInfo = priceInfo;

    }

    public readonly Guid Id;
    [ObservableProperty]
    private string? _symbol;
    [ObservableProperty]
    private string? _companyName;
    [ObservableProperty]
    private string? _marketCap;
    [ObservableProperty]
    private string? _yearFounded;
    [ObservableProperty]
    private int _numberOfEmployees;
    [ObservableProperty]
    private string? _city;
    [ObservableProperty]
    private string? _state;
    [ObservableProperty]
    private CompanyPriceInfo? _priceInfo;
}


