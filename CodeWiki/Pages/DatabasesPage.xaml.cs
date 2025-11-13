using CodeWiki.ViewModels;

namespace CodeWiki.Pages;

public partial class DatabasesPage : ContentPage
{
    public DatabasesPage(DatabasesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}