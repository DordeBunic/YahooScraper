using System.ComponentModel;
using System.Globalization;
using YahooScraper.Resources.Strings;

namespace YahooScraper.Helpers
{
    public class LocalizationResourceManager : INotifyPropertyChanged
    {
        public CultureInfo CurrentCulture => AppResources.Culture;

        private LocalizationResourceManager()
        {
            AppResources.Culture = CultureInfo.CurrentCulture;
        }

        public static LocalizationResourceManager Instance { get; } = new();

        public object this[string resourceKey]
            => AppResources.ResourceManager.GetObject(resourceKey, AppResources.Culture) ?? Array.Empty<byte>();

        public event PropertyChangedEventHandler? PropertyChanged;

        public void SetCulture(string? code)
        {
            CultureInfo.CurrentCulture = code switch
            {
                "ENG" => new CultureInfo("en-US", false),
                "BiH" => new CultureInfo("bs-latn", false),
                _ => new CultureInfo("en-US", false),
            };

            AppResources.Culture = CultureInfo.CurrentCulture;
            Thread.CurrentThread.CurrentUICulture =
            Thread.CurrentThread.CurrentCulture =
            CultureInfo.CurrentCulture;


            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            
            if(!string.IsNullOrEmpty(code))
                SecureStorage.SetAsync("LanguageCode", code);
        }

    }
}
