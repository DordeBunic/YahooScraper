using System.Collections.ObjectModel;
using YahooScraper.Models.Domain;

namespace YahooScraper.Interfaces.Api;

public interface IYahooFinanceService
{
    Task<ObservableCollection<QuoteItem>> GetTickers(string searchData);
    Task<CompanyInfo> GetCompanyInfo(string searchData);
    Task<CompanyPriceInfo?> GetTickerOnSelectedDate(CompanyInfo company, DateTime startDate);

}
