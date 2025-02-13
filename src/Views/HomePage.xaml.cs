using DevExpress.Maui.Core.Internal;
using DevExpress.Maui.DataGrid;

namespace YahooScraper.Views;
public partial class HomePage : ContentPage
{
	public HomePage()
	{
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