using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using YahooScraper.Models.Domain;

namespace YahooScraper.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;
        
        [ObservableProperty] 
        private string? _searchInput;

        [ObservableProperty] 
        private DateTime _selectedDate = DateTime.Now;

        [ObservableProperty]
        private bool _isSearchOpen;
        
        [ObservableProperty]
        private ObservableCollection<QuoteItem> _quoteItems = [];

        [ObservableProperty]
        private QuoteItem? _selectedQuoteItem;

        [ObservableProperty]
        private CompanyInfo? _selectedCompany;
    
        [ObservableProperty]
        private ObservableCollection<CompanyPriceInfo>? _selectedCompanyPrices;

        [ObservableProperty]
        private ObservableCollection<CompanyInfo>? _myCompanies = [];
    
        public DateTime MinDate => DateTime.Today.AddDays(-59);
        public DateTime TodayDate => DateTime.Today;
    
        [ObservableProperty]
        private bool _myCompaniesIsRefreshing;
    
        [ObservableProperty]
        private bool _isLoadingPrices;
        
        [ObservableProperty]
        private List<Language> _allLanguages = [ 
            new Language() {Name = "ENG"},  
            new Language() {Name = "BiH"} 
        ];

        [ObservableProperty] 
            private Language? _selectedLanguage;

    }
}
