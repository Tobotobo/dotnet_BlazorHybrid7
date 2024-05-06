using BlazorHybrid.Model.Entities;
using BlazorHybrid.Model.Interfaces;

namespace BlazorHybrid.Model.Impl;

public class WeatherForecastService : IWeatherForecastService
{
    public static string[] Summaries { get; } = [
            "凍結", "冷え込み", "寒い", "涼しい", "穏やか",
            "暖かい", "ぽかぽか", "暑い", "蒸し暑い", "焼けるよう"
        ];

    public async Task<WeatherForecast[]> GetWeatherForecastsAsync(int count)
    {
        await Task.Delay(500);

        var startDate = DateOnly.FromDateTime(DateTime.Now);
        // var summaries = new[] {
        //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", 
        // "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        var forecasts = Enumerable.Range(1, count).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray();

        return forecasts;
    }
}
