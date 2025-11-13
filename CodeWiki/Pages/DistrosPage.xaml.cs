using CodeWiki.ViewModels;

namespace CodeWiki.Pages;

public partial class DistrosPage : ContentPage
{
    public DistrosPage(DistrosViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}