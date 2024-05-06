using BlazorHybrid.Model.Interfaces;
using BlazorHybrid.Model.Impl;
using BlazorHybrid.View;
using BlazorHybrid.ViewState;
using BlazorHybrid.ViewState.Impl;
using Microsoft.Extensions.DependencyInjection;

#if DEBUG
using BlazorHybrid.Model.Impl.Mock;
using BlazorHybrid.ViewState.Impl.Mock;
#endif

namespace BlazorHybrid.App;

public static class AppServiceCollectionExtensions
{
    public static IServiceCollection AddApp(this IServiceCollection services, string connectionString)
    {
        services
            .AddView()

            // .AddTransient<ICounterState, CounterState>()
            // .AddScoped<ICounterState, CounterState>()
            .AddSingleton<ICounterState, CounterState>()
            // .AddSingleton<ICounterState, CounterStateMock>()

            .AddTransient<IWeatherState, WeatherState>()
            // .AddTransient<IWeatherState, WeatherStateMock>()

            .AddTransient<ITodoState, TodoState>()
            // .AddTransient<ITodoState, TodoStateMock>()

            .AddSingleton<ICounterService, CounterService>()

            .AddSingleton<IWeatherForecastService, WeatherForecastService>()
            // .AddSingleton<IWeatherForecastService, WeatherForecastServiceMock>()

            .AddSingleton(_ =>
            {
                // var context = new TodoContext("Data Source=:memory:");
                // var context = new TodoContext("Data Source=test.db;mode=memory;");
                var context = new TodoContext(connectionString);
                context.Database.EnsureCreated();
                return context;
            })

            .AddSingleton<ITodoRepository, TodoRepository>()
            // .AddSingleton<ITodoRepository, TodoRepositoryMock>()

            .AddSingleton<ITodoService, TodoService>()
        // .AddSingleton<ITodoService, TodoServiceMock>()
        ;

        return services;
    }
}
