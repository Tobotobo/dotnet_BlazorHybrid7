using BlazorHybrid.ViewState;

namespace BlazorHybrid.ViewState.Impl.Mock;

public class CounterStateMock : ICounterState
{
    public int CurrentCount { get; private set; } = 999;

    public void Clear()
    {
        CurrentCount = 111;
    }

    public void DecrementCount()
    {
        CurrentCount = 222;
    }

    public void IncrementCount()
    {
        CurrentCount = 333;
    }
}
