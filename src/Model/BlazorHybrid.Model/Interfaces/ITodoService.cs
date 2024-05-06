using BlazorHybrid.Model.Entities;

namespace BlazorHybrid.Model.Interfaces;

public interface ITodoService
{
    Task<Todo[]> GetTodosAsync();

    Task<Todo> AddTodoAsync(string title);

    Task UpdateTodoTitleAsync(Todo todo, string title);

    Task UpdateTodoIsDoneAsync(Todo todo, bool isDone);
}
