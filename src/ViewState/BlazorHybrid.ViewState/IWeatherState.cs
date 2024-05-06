using BlazorHybrid.Model.Entities;

namespace BlazorHybrid.ViewState;

public interface IWeatherState
{
    WeatherForecast[]? WeatherForecasts { get; }

    Task LoadWeatherForecastsAsync();
}
