using System.Collections.ObjectModel;
using YahooScraper.Models.Domain;

namespace YahooScraper.Interfaces.Db;

public interface ICompanyInterface
{
    Task<ObservableCollection<CompanyInfo>> GetCompanies();
    Task<bool> AddCompany(CompanyInfo companyInfo);
    Task<bool> RemoveCompany(Guid companyId);
    
    Task<ObservableCollection<CompanyPriceInfo>> GetAllCompanyPrices(Guid companyId);
    Task<CompanyPriceInfo?> GetCompanyPrice(Guid companyId, DateTime date);
    Task<bool> AddOrUpdateCompanyPrice(CompanyPriceInfo companyPrice);
}