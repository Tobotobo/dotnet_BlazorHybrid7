using BlazorHybrid.Model.Entities;

namespace BlazorHybrid.ViewState;

public interface ITodoState
{
    Todo[]? Todos { get; }

    string? NewTodoTitle { get; set; }

    Task LoadTodos();

    Task AddTodo();

    Task UpdateTodoTitle(Todo todo, string title);

    Task UpdateTodoIsDone(Todo todo, bool isDone);
}
