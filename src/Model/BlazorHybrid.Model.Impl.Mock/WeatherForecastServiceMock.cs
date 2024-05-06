using BlazorHybrid.Model.Entities;
using BlazorHybrid.Model.Interfaces;

namespace BlazorHybrid.Model.Impl.Mock;

public class WeatherForecastServiceMock : IWeatherForecastService
{
    public async Task<WeatherForecast[]> GetWeatherForecastsAsync(int count)
    {
        await Task.Delay(500);

        return [
            new WeatherForecast {
                Date = new DateOnly(2024, 4, 29),
                Summary = "あいうえお",
                TemperatureC = 20,
            },
            new WeatherForecast {
                Date = new DateOnly(2024, 4, 30),
                Summary = "かきくけこ",
                TemperatureC = 30,
            },
            new WeatherForecast {
                Date = new DateOnly(2024, 5, 1),
                Summary = "さしすせそ",
                TemperatureC = 40,
            },
        ];
    }
}
