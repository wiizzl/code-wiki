using CodeWiki.Pages.Details;

namespace CodeWiki;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        
        Routing.RegisterRoute("LanguagePage", typeof(LanguagePage));
        Routing.RegisterRoute("DatabasePage", typeof(DatabasePage));
        Routing.RegisterRoute("DistroPage", typeof(DistroPage));
    }
}