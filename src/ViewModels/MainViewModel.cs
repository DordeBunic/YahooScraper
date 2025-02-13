using CommunityToolkit.Mvvm.Input;
using YahooScraper.Helpers;
using YahooScraper.Implementation.Db;
using YahooScraper.Interfaces.Api;
using YahooScraper.Interfaces.Db;
using YahooScraper.Models.Domain;
using YahooScraper.Resources.Strings;
using YahooScraper.Views;

namespace YahooScraper.ViewModels;
public partial class MainViewModel : BaseViewModel
{
    private readonly IYahooFinanceService _yahooFinanceService;
    private readonly ICompanyInterface _companyInterface;
    private readonly DatabaseContext _context;

    public MainViewModel(IYahooFinanceService yahooFinanceService, DatabaseContext context, ICompanyInterface companyInterface)
    {
        _yahooFinanceService = yahooFinanceService;
        _companyInterface = companyInterface;
        _context = context;

        new Thread(LoadLanguage).Start();
        new Thread(LoadData).Start();
    }

    private async void LoadLanguage()
    {
        try
        {
            var cultureCode = await SecureStorage.GetAsync("LanguageCode");
            if (!string.IsNullOrEmpty(cultureCode))
            {
                LocalizationResourceManager.Instance.SetCulture(cultureCode);
                SelectedLanguage = AllLanguages.FirstOrDefault(x => x.Name == cultureCode);
            }
            else
                SelectedLanguage = AllLanguages.FirstOrDefault();
        }
        catch (Exception)
        {
            // ignored
        }
    }

    private async void LoadData()
    {
        try
        {
            await _context.InitializeAsync();
            MyCompanies = await _companyInterface.GetCompanies();
            foreach (var item in MyCompanies)
            {
                item.PriceInfo = await GetCompanyPrice(item, SelectedDate);
            }
            MyCompaniesIsRefreshing = false;
        }
        catch (Exception)
        {
            // ignored
        }
    }

    [RelayCommand]
    private void ReloadCompanyData()
    {
        MyCompaniesIsRefreshing = true;
        LoadData();
    }

    [RelayCommand]
    private async Task ReloadCompanyPricesData()
    {
        IsLoadingPrices = true;
        if(SelectedCompany != null && SelectedCompany.Id != Guid.Empty)
            SelectedCompanyPrices = await _companyInterface.GetAllCompanyPrices(SelectedCompany.Id);
        IsLoadingPrices = false;
    }


    [RelayCommand]
    private async Task SearchChanged()
    {
        if (SelectedQuoteItem != null)
            return;
        if (string.IsNullOrEmpty(SearchInput))
        {
            QuoteItems = [];
            return;
        }

        QuoteItems = await _yahooFinanceService.GetTickers(SearchInput);
    }

    [RelayCommand]
    private async Task AddQuote(QuoteItem item)
    {
        if (string.IsNullOrEmpty(item.Symbol) || MyCompanies == null)
            return;
        if (MyCompanies.Any(x => x.Symbol == item.Symbol))
        {
            ShowAlert( string.Format(AppResources.ResourceManager.GetString("ItemExistTitle", LocalizationResourceManager.Instance.CurrentCulture) ?? "", item.Symbol),
                AppResources.ResourceManager.GetString("ItemExistMessage", LocalizationResourceManager.Instance.CurrentCulture) ?? "",
                AppResources.ResourceManager.GetString("OkLabel", LocalizationResourceManager.Instance.CurrentCulture) ?? "");
            await ResetSearch();
            return;
        }

        var result = await _yahooFinanceService.GetCompanyInfo(item.Symbol);

        MyCompanies.Add(result);
        await _companyInterface.AddCompany(result);
        var index = MyCompanies.Count - 1;
        await ResetSearch();

        MyCompanies[index].PriceInfo = await GetCompanyPrice(result, SelectedDate);
    }

    private async Task ResetSearch()
    {
        SearchInput = string.Empty;
        SelectedQuoteItem = null;
        await Task.Delay(250);
        IsSearchOpen = false;
    }

    [RelayCommand]
    private async Task DeleteItem(CompanyInfo item)
    {
        if (!await ShowDialog(string.Format(AppResources.ResourceManager.GetString("DeleteItemTitle", LocalizationResourceManager.Instance.CurrentCulture) ?? "", item.Symbol), 
                AppResources.ResourceManager.GetString("DeleteItemMessage", LocalizationResourceManager.Instance.CurrentCulture) ?? "",
                AppResources.ResourceManager.GetString("NoLabel", LocalizationResourceManager.Instance.CurrentCulture) ?? "",
                AppResources.ResourceManager.GetString("YesLabel", LocalizationResourceManager.Instance.CurrentCulture) ?? ""))
            return;
        if(MyCompanies == null)
            return;
        MyCompanies.Remove(item);
        await _companyInterface.RemoveCompany(item.Id);
    }

    [RelayCommand]
    private async Task NavigateToDetails(CompanyInfo item)
    {
        SelectedCompany = item;
        Application.Current?.MainPage?.Navigation.PushAsync(new DetailsView(this));
        SelectedCompanyPrices = await _companyInterface.GetAllCompanyPrices(item.Id);
    }


    [RelayCommand]
    private async Task DateChanged()
    {
        foreach (var item in MyCompanies ?? [])
        {
            if(string.IsNullOrEmpty(item.Symbol))
                continue;
            
            item.PriceInfo = await GetCompanyPrice(item, SelectedDate);
        }
    }

    private async Task<CompanyPriceInfo?> GetCompanyPrice(CompanyInfo company, DateTime date)
    {
        
        var price = await _companyInterface.GetCompanyPrice(company.Id, date);
        if(price is { OpenPrice: not null })
            return price;
        
        var result = await _yahooFinanceService.GetTickerOnSelectedDate(company, date);
        if(result != null)
            await _companyInterface.AddOrUpdateCompanyPrice(result);
        return result;
    }
    
    private async Task<bool> ShowDialog(string title, string message, string cancelText, string acceptText)
    {
        return await Application.Current!.MainPage!.DisplayAlert(title, message, acceptText, cancelText);
    }
    private void ShowAlert(string title, string message, string cancelText)
    {
        Application.Current!.MainPage!.DisplayAlert(title, message, cancelText);
    }

    [RelayCommand]
    private void LanguageChanged(Language language)
    {
        LocalizationResourceManager.Instance.SetCulture(language.Name);
    }

    [RelayCommand]
    private void Submit(object a)
    {
        if (QuoteItems.Count == 0)
            return;
        AddQuoteCommand.Execute(QuoteItems[0]);
    }
}
