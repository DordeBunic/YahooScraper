using CommunityToolkit.Mvvm.ComponentModel;

using YahooScraper.Models.Api;

namespace YahooScraper.Models.Domain
{
    public partial class QuoteItem : ObservableObject
    {
        public QuoteItem()
        {
                
        }
        public QuoteItem(Quote quote)
        {
            Symbol = quote.Symbol;
            Name = quote.Shortname;            
        }

        public string SearchValue => $"{Symbol} - {Name}";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SearchValue))]
        private string? _symbol;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SearchValue))]
        private string? _name;

    }
}
