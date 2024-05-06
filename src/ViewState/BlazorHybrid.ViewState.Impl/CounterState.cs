using BlazorHybrid.Model.Interfaces;

namespace BlazorHybrid.ViewState.Impl;

public class CounterState(ICounterService counterService) : ICounterState
{
    public int CurrentCount { get; set; }

    public void IncrementCount()
    {
        CurrentCount = counterService.IncrementCount(CurrentCount);
    }

    public void DecrementCount()
    {
        CurrentCount = counterService.DecrementCount(CurrentCount);
    }

    public void Clear()
    {
        CurrentCount = 0;
    }
}
