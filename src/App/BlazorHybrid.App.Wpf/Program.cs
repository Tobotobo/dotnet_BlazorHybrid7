using System.IO;
using System.Windows;
using Microsoft.AspNetCore.Components.WebView.Wpf;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorHybrid.App.Wpf;

static class Program
{
    [STAThread]
    static void Main()
    {
        var dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "com.github.tobotobo",
            "BlazorHybrid.App",
            "todo.db");
        Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

        var app = new App();

        app.Services
            .AddApp($"Data Source={dbPath}")
            .AddWpfBlazorWebView();

        app.Run();
    }

    class App : Application
    {
        public IServiceCollection Services { get; } = new ServiceCollection();

        protected override void OnStartup(StartupEventArgs e)
        {
            var window = new Window
            {
                Title = "BlazorHybrid.App.Wpf",
                Width = 1024,
                Height = 700,
            };

            var blazorWebView = new BlazorWebView
            {
                HostPage = "wwwroot\\index.html",
                Services = Services.BuildServiceProvider(),
                RootComponents = { new RootComponent
                {
                    Selector = "#app",
                    ComponentType = typeof(BlazorHybrid.View.Components.Routes),
                } },
            };
            window.Content = blazorWebView;

            window.Show();
        }
    }
}
