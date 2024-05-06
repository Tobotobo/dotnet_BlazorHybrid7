using BlazorHybrid.Model.Entities;

namespace BlazorHybrid.ViewState.Impl.Mock;

public class WeatherStateMock : IWeatherState
{
    public WeatherForecast[]? WeatherForecasts { get; private set; }

    public async Task LoadWeatherForecastsAsync()
    {
        await Task.Delay(500);

        WeatherForecasts = [
            new WeatherForecast {
                Date = new DateOnly(2024, 4, 29),
                Summary = "あいうえお",
                TemperatureC = 20,
            }
        ];
    }
}
