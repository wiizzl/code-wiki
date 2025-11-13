using CodeWiki.ViewModels;

namespace CodeWiki.Pages;

public partial class LanguagesPage : ContentPage
{
    public LanguagesPage(LanguagesViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}