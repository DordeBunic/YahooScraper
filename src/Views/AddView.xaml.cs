using DevExpress.Maui.Core.Internal;
using DevExpress.Maui.DataGrid;
using DevExpress.Maui.Editors;

namespace YahooScraper.Views;

public partial class AddView : ContentPage
{
    public AddView()
    {
        InitializeComponent();
    }
    
    private void SelectionChanged(object? sender, EventArgs e)
    {
        if (sender is AutoCompleteEdit autoCompleteEdit)
        {
            autoCompleteEdit.Unfocus();
        }
    }

    private void DataGridView_CustomCellAppearance(object sender, CustomCellAppearanceEventArgs e)
    {
        if (e.RowHandle % 2 == 1)
            e.BackgroundColor = (Color?)Application.Current?.Resources.GetValueOrDefault("Gray100");
        else
            e.BackgroundColor = Colors.White;
    }
}