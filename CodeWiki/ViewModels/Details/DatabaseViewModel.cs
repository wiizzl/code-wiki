using CodeWiki.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CodeWiki.ViewModels.Details;

public partial class DatabaseViewModel : ObservableObject, IQueryAttributable
{
    [ObservableProperty]
    private Database _database;
    
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Database = (Database)query["Database"];
    }

    public DatabaseViewModel()
    {
        
    }
}