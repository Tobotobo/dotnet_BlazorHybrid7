using BlazorHybrid.Model.Interfaces;
using Moq;

namespace BlazorHybrid.ViewState.Impl.Test;

public class CounterStateTest
{
    CounterState? _counterState;

    [SetUp]
    public void Setup()
    {
        var counterServiceMock = new Mock<ICounterService>();
        counterServiceMock.Setup(x => x.IncrementCount(1)).Returns(2);
        counterServiceMock.Setup(x => x.DecrementCount(-1)).Returns(-2);

        _counterState = new CounterState(
            counterServiceMock.Object
            );
    }

    [Test]
    public void 初期値()
    {
        var result = _counterState!.CurrentCount;
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void IncrementCount()
    {
        _counterState!.CurrentCount = 1;
        _counterState!.IncrementCount();
        var result = _counterState!.CurrentCount;
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void DecrementCount()
    {
        _counterState!.CurrentCount = -1;
        _counterState!.DecrementCount();
        var result = _counterState!.CurrentCount;
        Assert.That(result, Is.EqualTo(-2));
    }

    [Test]
    public void Clear()
    {
        _counterState!.CurrentCount = 999;
        _counterState!.Clear();
        var result = _counterState!.CurrentCount;
        Assert.That(result, Is.EqualTo(0));
    }
}
