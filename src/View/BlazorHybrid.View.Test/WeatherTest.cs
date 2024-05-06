using BlazorHybrid.ViewState;
using BlazorHybrid.View.Components.Pages;
using System.Linq;
using AngleSharp.Dom;
using BlazorHybrid.Model.Entities;
using System;

namespace BlazorHybrid.View.Test;

public class WeatherTest : BunitTestContext
{
    Mock<IWeatherState>? _stateMock;

    [SetUp]
    public new void Setup()
    {
        _stateMock = new Mock<IWeatherState>();
        Services.AddSingleton<IWeatherState>(_stateMock!.Object);
    }

    [Test]
    public void 読込中_Loadingが表示されること()
    {
        _stateMock!.Setup(x => x.WeatherForecasts).Returns((WeatherForecast[]?)null);
        var view = RenderComponent<Weather>();
        view
            .Find("p")
            .NextElementSibling!
            .MarkupMatches(@"
                <p><em>Loading...</em></p>
            ");
    }

    [Test]
    public void 読込後_一覧が表示されること()
    {
        _stateMock!.Setup(x => x.WeatherForecasts).Returns([
            new WeatherForecast {
                Date = new DateOnly(2024, 4, 10),
                TemperatureC = 20,
                Summary = "あいうえお"
            },
            new WeatherForecast {
                Date = new DateOnly(1989, 12, 25),
                TemperatureC = 30,
                Summary = "かきくけこ"
            },
        ]);
        var view = RenderComponent<Weather>();
        view
            .Find("tbody")
            .MarkupMatches(@"
                <tbody>
                <tr>
                    <td>令和 6 年 4 月 10 日</td>
                    <td>20</td>
                    <td>67</td>
                    <td>あいうえお</td>
                </tr>
                <tr>
                    <td>平成 1 年 12 月 25 日</td>
                    <td>30</td>
                    <td>85</td>
                    <td>かきくけこ</td>
                </tr>
                </tbody>
            ");
    }
}
