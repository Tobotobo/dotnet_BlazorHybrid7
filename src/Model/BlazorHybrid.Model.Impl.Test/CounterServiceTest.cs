using System.Runtime.CompilerServices;

namespace BlazorHybrid.Model.Impl.Test;

public class CounterServiceTest
{
    private CounterService? _counterService;

    [SetUp]
    public void Setup()
    {
        _counterService = new CounterService();
    }

    [TestCase(1, 2)]
    [TestCase(0, 1)]
    [TestCase(-1, 0)]
    public void IncrementCount_1加算されること(int currentCount, int actual)
    {
        var result = _counterService!.IncrementCount(currentCount);
        Assert.That(result, Is.EqualTo(actual));
    }

    [TestCase(1, 0)]
    [TestCase(0, -1)]
    [TestCase(-1, -2)]
    public void DecrementCount_1減算されること(int currentCount, int actual)
    {
        var result = _counterService!.DecrementCount(currentCount);
        Assert.That(result, Is.EqualTo(actual));
    }
}
