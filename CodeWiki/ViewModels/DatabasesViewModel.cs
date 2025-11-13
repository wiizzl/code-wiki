using System.Collections.ObjectModel;
using CodeWiki.Models;
using CodeWiki.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CodeWiki.ViewModels;

public partial class DatabasesViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;
    
    [ObservableProperty]
    private ObservableCollection<Database> _databases;
    
    public DatabasesViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        Databases = new ObservableCollection<Database>(_databaseService.GetDatabases());
    }
    
    [RelayCommand]
    private void OpenDetailPage(Database database)
    {
        Shell.Current.GoToAsync("DatabasePage", true, new Dictionary<string, object>
        {
            { "Database", database }
        });
    }
}