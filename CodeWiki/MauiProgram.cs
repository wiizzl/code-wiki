using CodeWiki.Pages;
using CodeWiki.Pages.Details;
using CodeWiki.Services;
using CodeWiki.ViewModels;
using CodeWiki.ViewModels.Details;
using Microsoft.Extensions.Logging;

namespace CodeWiki;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        
        builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddSingleton<AppShell>();
        
        builder.Services.AddSingleton<LanguagesViewModel>();
        builder.Services.AddSingleton<DatabasesViewModel>();
        builder.Services.AddSingleton<DistrosViewModel>();
        
        builder.Services.AddSingleton<LanguageViewModel>();
        builder.Services.AddSingleton<DatabaseViewModel>();
        builder.Services.AddSingleton<DistroViewModel>();
        
        builder.Services.AddSingleton<LanguagesPage>();
        builder.Services.AddSingleton<DatabasesPage>();
        builder.Services.AddSingleton<DistrosPage>();
        
        builder.Services.AddSingleton<LanguagePage>();
        builder.Services.AddSingleton<DatabasePage>();
        builder.Services.AddSingleton<DistroPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}