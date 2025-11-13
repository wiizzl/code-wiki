using System.Collections.ObjectModel;
using CodeWiki.Models;
using CodeWiki.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CodeWiki.ViewModels;

public partial class LanguagesViewModel : ObservableObject
{
    private readonly DatabaseService _databaseService;
    
    [ObservableProperty]
    private ObservableCollection<Language> _languages;
    
    public LanguagesViewModel(DatabaseService databaseService)
    {
        _databaseService = databaseService;
        Languages = new ObservableCollection<Language>(_databaseService.GetLanguages());
    }
    
    [RelayCommand]
    private void OpenDetailPage(Language language)
    {
        Shell.Current.GoToAsync("LanguagePage", true, new Dictionary<string, object>
        {
            { "Language", language }
        });
    }
}