using CommunityToolkit.Maui;
using DevExpress.Maui;
using Microsoft.Extensions.Logging;
using YahooScraper.Helpers.Http;
using YahooScraper.Implementation.Api;
using YahooScraper.Implementation.Db;
using YahooScraper.Interfaces.Api;
using YahooScraper.Interfaces.Db;
using YahooScraper.ViewModels;
using YahooScraper.Views;

namespace YahooScraper
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseDevExpress(useLocalization: false)
                .UseDevExpressControls()
                .UseDevExpressCollectionView()
                .UseDevExpressEditors()
                .UseDevExpressDataGrid()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

#region Services
            builder.Services.AddSingleton<DatabaseContext>();
            builder.Services.AddSingleton<ICompanyInterface,CompanyInterface>();
#endregion

#region ViewModels
            builder.Services.AddSingleton<MainViewModel>();
#endregion

#region Views
            builder.Services.AddViewModel<MainViewModel, HomePage>();
            builder.Services.AddViewModel<MainViewModel, AddView>();
            builder.Services.AddViewModel<MainViewModel, SettingsView>();
            
            builder.Services.AddTransient<DetailsView>();
#endregion

#region HttpClient
            builder.Services.AddSingleton(new CustomHttpClient(new CustomHttpHandler()));
            builder.Services.AddHttpClient<IYahooFinanceService, YahooFinanceService>(c => new CustomHttpClient(new CustomHttpHandler()));
            builder.Services.AddSingleton<IYahooFinanceService, YahooFinanceService>();
#endregion


            return builder.Build();
        }

        private static void AddViewModel<TViewModel, TView>(this IServiceCollection services)
        where TView : ContentPage, new()
        where TViewModel : class
        {
            services.AddTransient<TView>(s => new TView() { BindingContext = s.GetRequiredService<TViewModel>() });
        }
    }
}
