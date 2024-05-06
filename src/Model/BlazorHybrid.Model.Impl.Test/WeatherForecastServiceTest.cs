using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using BlazorHybrid.Model.Entities;

namespace BlazorHybrid.Model.Impl.Test;

public class WeatherForecastServiceTest
{
    private WeatherForecastService? _weatherForecastService;

    [SetUp]
    public void Setup()
    {
        _weatherForecastService = new WeatherForecastService();
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(10)]
    public async Task GetWeatherForecast(int count)
    {
        var result = await _weatherForecastService!.GetWeatherForecastsAsync(count);

        // 指定された件数か
        Assert.That(result, Has.Length.EqualTo(count));
        Assert.That(result, Has.All.Matches<WeatherForecast>(x =>
            // TemperatureC が -20 以上 55 以下か
            x.TemperatureC >= -20 && x.TemperatureC <= 55
            // Summary が Summaries のいずれかか
            && Is.AnyOf(WeatherForecastService.Summaries).ApplyTo(x.Summary).IsSuccess
            // Date に設定された日付が 1901/1/1 から 2099/3/31 の間か
            && x.Date >= new DateOnly(1901, 1, 1) && x.Date <= new DateOnly(2099, 3, 31)
        ));
    }
}
