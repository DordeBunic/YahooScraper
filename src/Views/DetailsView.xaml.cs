using DevExpress.Maui.Core.Internal;
using DevExpress.Maui.DataGrid;
using YahooScraper.ViewModels;

namespace YahooScraper.Views;

public partial class DetailsView : ContentPage
{
    public DetailsView(MainViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
    }
    private void DataGridView_CustomCellAppearance(object sender, CustomCellAppearanceEventArgs e)
    {
        if (e.RowHandle % 2 == 1)
            e.BackgroundColor = (Color?)Application.Current?.Resources.GetValueOrDefault("Gray100");
        else
            e.BackgroundColor = Colors.White;
    }
}