using BlazorHybrid.ViewState;
using BlazorHybrid.View.Components.Pages;
using System.Linq;

namespace BlazorHybrid.View.Test;

public class CounterTest : BunitTestContext
{
    Mock<ICounterState>? _stateMock;

    [SetUp]
    public new void Setup()
    {
        _stateMock = new Mock<ICounterState>();
        Services.AddSingleton<ICounterState>(_stateMock!.Object);
    }

    [Test]
    public void CurrentCount_表示されること()
    {
        _stateMock!.Setup(x => x.CurrentCount).Returns(999);
        var view = RenderComponent<Counter>();
        view.Find("p").MarkupMatches("<p role=\"status\">Current count: 999</p>");
    }

    [Test]
    public void IncrementCount_呼ばれること()
    {
        var view = RenderComponent<Counter>();
        view
            .FindAll("button")
            .First(x => x.TextContent == "+")
            .Click();
        // Never      : 一度も呼ばれていない
        // Once       : ちょうど一回呼ばれた
        // AtLeastOnce: 少なくとも一回は呼ばれた
        // Exactly    : 指定された回数だけメソッドが呼ばれた　※引数で回数を指定
        // AtMostOnce : 0回か1回だけ呼ばれた
        _stateMock!.Verify(x => x.IncrementCount(), Times.Once());
    }

    [Test]
    public void DecrementCount_呼ばれること()
    {
        var view = RenderComponent<Counter>();
        view
            .FindAll("button")
            .First(x => x.TextContent == "-")
            .Click();
        _stateMock!.Verify(x => x.DecrementCount(), Times.Once());
    }

    [Test]
    public void Clear_呼ばれること()
    {
        var view = RenderComponent<Counter>();
        view
            .FindAll("button")
            .First(x => x.TextContent == "clear")
            .Click();
        _stateMock!.Verify(x => x.Clear(), Times.Once());
    }
}
