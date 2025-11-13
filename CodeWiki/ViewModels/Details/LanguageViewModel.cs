using CodeWiki.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CodeWiki.ViewModels.Details;

public partial class LanguageViewModel : ObservableObject, IQueryAttributable
{
    [ObservableProperty]
    private Language _language;
    
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Language = (Language)query["Language"];
    }

    public LanguageViewModel()
    {
        
    }
}