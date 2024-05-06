namespace BlazorHybrid.Model.Interfaces;

public interface ICounterService
{
    int IncrementCount(int currentCount);

    int DecrementCount(int currentCount);
}
