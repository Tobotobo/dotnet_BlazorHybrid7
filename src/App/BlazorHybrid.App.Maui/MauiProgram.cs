using Microsoft.Extensions.Logging;

namespace BlazorHybrid.App.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var dbPath = Path.Combine(
            FileSystem.Current.AppDataDirectory,
            "todo.db");
        Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services
            .AddApp($"Data Source={dbPath}")
            .AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
