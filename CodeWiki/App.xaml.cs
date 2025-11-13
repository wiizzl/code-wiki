namespace CodeWiki;

public partial class App : Application
{
    private AppShell _shell { get; set; }
    
    public App(AppShell shell)
    {
        InitializeComponent();
        _shell = shell;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(_shell);
    }
}