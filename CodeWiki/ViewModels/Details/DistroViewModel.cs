using CodeWiki.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CodeWiki.ViewModels.Details;

public partial class DistroViewModel : ObservableObject, IQueryAttributable
{
    [ObservableProperty]
    private Distro _distro;
    
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Distro = (Distro)query["Distro"];
    }

    public DistroViewModel()
    {
        
    }
}