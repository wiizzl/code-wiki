using CodeWiki.ViewModels.Details;

namespace CodeWiki.Pages.Details;

public partial class DistroPage : ContentPage
{
    public DistroPage(DistroViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}