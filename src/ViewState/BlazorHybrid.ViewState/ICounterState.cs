namespace BlazorHybrid.ViewState;

public interface ICounterState
{
    int CurrentCount { get; }

    void IncrementCount();

    void DecrementCount();

    void Clear();
}
