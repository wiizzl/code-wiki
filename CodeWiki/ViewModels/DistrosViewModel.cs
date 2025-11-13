using System.Collections.ObjectModel;
using CodeWiki.Models;
using CodeWiki.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CodeWiki.ViewModels;

public partial class DistrosViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;
    
    [ObservableProperty]
    private ObservableCollection<Distro> _distros;
    
    public DistrosViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        Distros = new ObservableCollection<Distro>(_databaseService.GetDistros());
    }
    
    [RelayCommand]
    private void OpenDetailPage(Distro distro)
    {
        Shell.Current.GoToAsync("DistroPage", true, new Dictionary<string, object>
        {
            { "Distro", distro }
        });
    }
}