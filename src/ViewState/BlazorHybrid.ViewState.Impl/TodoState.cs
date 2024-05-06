using BlazorHybrid.Model.Entities;
using BlazorHybrid.Model.Interfaces;

namespace BlazorHybrid.ViewState.Impl;

public class TodoState(ITodoService todoService) : ITodoState
{
    public Todo[]? Todos { get; private set; }

    public string? NewTodoTitle { get; set; }

    public async Task LoadTodos()
    {
        Todos = await todoService.GetTodosAsync();
    }

    public async Task AddTodo()
    {
        if (!string.IsNullOrWhiteSpace(NewTodoTitle))
        {
            await todoService.AddTodoAsync(NewTodoTitle);
            NewTodoTitle = string.Empty;
            Todos = await todoService.GetTodosAsync();
        }
    }

    public async Task UpdateTodoTitle(Todo todo, string title)
    {
        if (!string.IsNullOrWhiteSpace(title))
        {
            await todoService.UpdateTodoTitleAsync(todo, title);
            Todos = await todoService.GetTodosAsync();
        }
    }

    public async Task UpdateTodoIsDone(Todo todo, bool isDone)
    {
        await todoService.UpdateTodoIsDoneAsync(todo, isDone);
        Todos = await todoService.GetTodosAsync();
    }
}
