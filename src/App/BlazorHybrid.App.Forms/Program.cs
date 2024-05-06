using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorHybrid.App.Forms;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        var dbPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "com.github.tobotobo",
            "BlazorHybrid.App",
            "todo.db");
        Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

        var services = new ServiceCollection();
        services
            .AddApp($"Data Source={dbPath}")
            .AddWindowsFormsBlazorWebView();

        Run(services);
    }

    static void Run(IServiceCollection services)
    {
        var form = new Form
        {
            AutoScaleMode = AutoScaleMode.Font,
            ClientSize = new Size(1024, 700),
            Text = "BlazorHybrid.App.Forms",
        };

        var blazorWebView = new BlazorWebView
        {
            Dock = DockStyle.Fill,
            HostPage = "wwwroot\\index.html",
            Services = services.BuildServiceProvider(),
        };
        blazorWebView.RootComponents.Add<BlazorHybrid.View.Components.Routes>("#app");
        form.Controls.Add(blazorWebView);

        Application.Run(form);
    }
}
