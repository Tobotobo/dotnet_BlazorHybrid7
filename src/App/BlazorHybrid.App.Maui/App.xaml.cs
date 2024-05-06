namespace BlazorHybrid.App.Maui;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // MainPage = new AppShell();
        // MainPage = new MainPage();
    }

    protected override Window CreateWindow(IActivationState? activationState) =>
        new Window(new AppShell())
        {
            Width = 1024,
            Height = 700,
        };
}
