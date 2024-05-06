using BlazorHybrid.Model.Entities;
using BlazorHybrid.Model.Interfaces;
using Moq;

namespace BlazorHybrid.ViewState.Impl.Test;

public class WeatherStateTest
{
    WeatherState? _weatherState;

    [SetUp]
    public void Setup()
    {
        var weatherForecastServiceMock = new Mock<IWeatherForecastService>();
        weatherForecastServiceMock
            .Setup(x => x.GetWeatherForecastsAsync(5))
            .ReturnsAsync(
                Enumerable.Range(1, 5).Select(i => new WeatherForecast
                {
                    Date = new DateOnly(2024, 4, 10 + i),
                    TemperatureC = 20 + i,
                    Summary = "Summary" + i
                }).ToArray());

        _weatherState = new WeatherState(
            weatherForecastServiceMock.Object);
    }

    [Test]
    public void 初期値()
    {
        var result = _weatherState!.WeatherForecasts;
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task LoadWeatherForecastsAsync()
    {
        await _weatherState!.LoadWeatherForecastsAsync();
        var result = _weatherState!.WeatherForecasts;
        Assert.That(result, Has.Length.EqualTo(5));
        Assert.That(result, Has.All.Not.Null);
    }
}
