using CodeWiki.ViewModels.Details;

namespace CodeWiki.Pages.Details;

public partial class DatabasePage : ContentPage
{
    public DatabasePage(DatabaseViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}