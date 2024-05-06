using BlazorHybrid.Model.Interfaces;

namespace BlazorHybrid.Model.Impl;

public class CounterService : ICounterService
{
    public int IncrementCount(int currentCount)
    {
        return currentCount + 1;
    }

    public int DecrementCount(int currentCount)
    {
        return currentCount - 1;
    }
}
