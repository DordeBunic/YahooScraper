using CommunityToolkit.Mvvm.ComponentModel;
using TeixeiraSoftware.Finance;
using YahooScraper.Models.Api;
using YahooScraper.Models.Db;

namespace YahooScraper.Models.Domain;

public partial class CompanyPriceInfo : ObservableObject
{
    public CompanyPriceInfo()
    {
        
    }

    public CompanyPriceInfo(Guid companyId, YahooCompanyPriceInfoDto dto, DateTime date)
    {
        Id = Guid.NewGuid();
        CompanyId = companyId;
        var data = dto.Chart?.Result?.FirstOrDefault();
        if (data == null)
            return;
        PreviousClosePrice = data.Meta?.ChartPreviousClose;
        OpenPrice = data.Indicators?.Quote?.FirstOrDefault()?.Open?.FirstOrDefault();
        DateTime = date;
        CurrencyCode = Currency.ByAlphabeticCode(data?.Meta?.Currency).Sign;
    }

    public CompanyPriceInfo(CompanyPriceInfoDto dto)
    {
        Id = dto.Id;
        CompanyId = dto.CompanyId;
        DateTime = dto.DateTime;
        PreviousClosePrice = dto.PreviousClosePrice;
        OpenPrice = dto.OpenPrice;
        CurrencyCode = dto.CurrencyCode;
    }

    public readonly Guid Id;
    public readonly Guid CompanyId;

    [ObservableProperty]
    private DateTime _dateTime;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof( PreviousClosePriceString))]
    private double? _previousClosePrice;
    public string? PreviousClosePriceString => PreviousClosePrice > 0 ? $"{CurrencyCode}{PreviousClosePrice:N2}" : null;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(OpenPriceString))]
    private double? _openPrice;
    public string? OpenPriceString => OpenPrice > 0 ? $"{CurrencyCode}{OpenPrice:N2}" : null;
    
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof( PreviousClosePriceString))]
    [NotifyPropertyChangedFor(nameof(OpenPriceString))]
    private string? _currencyCode;

}