using CodeWiki.ViewModels.Details;

namespace CodeWiki.Pages.Details;

public partial class LanguagePage : ContentPage
{
    public LanguagePage(LanguageViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}