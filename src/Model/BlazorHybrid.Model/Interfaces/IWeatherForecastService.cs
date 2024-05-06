using BlazorHybrid.Model.Entities;

namespace BlazorHybrid.Model.Interfaces;

public interface IWeatherForecastService
{
    Task<WeatherForecast[]> GetWeatherForecastsAsync(int count);
}
