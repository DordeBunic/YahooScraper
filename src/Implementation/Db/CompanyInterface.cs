using System.Collections.ObjectModel;
using YahooScraper.Interfaces.Db;
using YahooScraper.Models.Db;
using YahooScraper.Models.Domain;

namespace YahooScraper.Implementation.Db;

public class CompanyInterface : ICompanyInterface
{
    private readonly DatabaseContext _context;
    
    public CompanyInterface(DatabaseContext context)
    {
        _context = context;
    }
    public async Task<ObservableCollection<CompanyInfo>> GetCompanies()
    {
        var companies = new ObservableCollection<CompanyInfo>();
        var dbCompanies = await _context.GetAllAsync<CompanyInfoDto>();
        
        foreach (var item in dbCompanies)
        {
            companies.Add(new CompanyInfo(item));
        }
        return companies;
    }

    public async Task<bool> AddCompany(CompanyInfo companyInfo)
    {
        try
        {
            await _context.AddItemAsync(new CompanyInfoDto()
            {
                Id = companyInfo.Id,
                Symbol = companyInfo.Symbol,
                CompanyName = companyInfo.CompanyName,
                MarketCap = companyInfo.MarketCap,
                YearFounded = companyInfo.YearFounded,
                NumberOfEmployees = companyInfo.NumberOfEmployees,
                State = companyInfo.State,
                City = companyInfo.City,
            });
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> RemoveCompany(Guid companyId)
    {
        try
        {
            var allPrices = await _context.GetFilteredAsync<CompanyPriceInfoDto>(x=>x.CompanyId == companyId);
            foreach (var item in allPrices)
            {
               await _context.DeleteItemByKeyAsync<CompanyPriceInfoDto>(item.Id);
            }
            await _context.DeleteItemByKeyAsync<CompanyInfoDto>(companyId);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        
    }

    public async Task<ObservableCollection<CompanyPriceInfo>> GetAllCompanyPrices(Guid companyId)
    {
        var result = new ObservableCollection<CompanyPriceInfo>();
        var prices = await _context.GetFilteredAsync<CompanyPriceInfoDto>(x => x.CompanyId == companyId, x=>x.DateTime);
        foreach (var item in prices)
        {
            result.Add(new CompanyPriceInfo(item));
        }
        return result;
    }

    public async Task<CompanyPriceInfo?> GetCompanyPrice(Guid companyId, DateTime date)
    {
        var price = (await _context.GetFilteredAsync<CompanyPriceInfoDto>(x => x.CompanyId == companyId && x.DateTime == date)).ToList().FirstOrDefault();
        
        return price == null ? null : new CompanyPriceInfo(price);
    }

    public async Task<bool> AddOrUpdateCompanyPrice(CompanyPriceInfo companyPrice)
    {
        var priceExists = (await _context.GetFilteredAsync<CompanyPriceInfoDto>(x => x.CompanyId == companyPrice.CompanyId && x.DateTime == companyPrice.DateTime)).ToList();
        if (priceExists.Count > 0)
        {
            var oldPrice = priceExists.FirstOrDefault();
            if (oldPrice != null)
            {
                oldPrice.OpenPrice = companyPrice.OpenPrice;
                oldPrice.PreviousClosePrice = companyPrice.PreviousClosePrice;
                await _context.UpdateItemAsync(oldPrice);
                return true;
            }
          
        }
        await _context.AddItemAsync(new CompanyPriceInfoDto()
        {
            Id = companyPrice.Id,
            CompanyId = companyPrice.CompanyId,
            OpenPrice = companyPrice.OpenPrice,
            PreviousClosePrice = companyPrice.PreviousClosePrice,
            DateTime = companyPrice.DateTime,
            CurrencyCode = companyPrice.CurrencyCode,
        });
        return true;
    }
}