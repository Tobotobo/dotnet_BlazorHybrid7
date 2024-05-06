using BlazorHybrid.Model.Entities;

namespace BlazorHybrid.Model.Interfaces;

public interface ITodoRepository
{
    Task<Todo[]> GetTodosAsync();

    Task<Todo> AddTodoAsync(Todo todo);

    Task UpdateTodoAsync(Todo todo);

    Task RemoveTodoAsync(Todo todo);
}
