using System.Data.Common;
using BlazorHybrid.Model.Entities;
using BlazorHybrid.Model.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BlazorHybrid.Model.Impl;

public class TodoService(ITodoRepository todoRepository) : ITodoService
{
    public Task<Todo[]> GetTodosAsync()
    {
        return todoRepository.GetTodosAsync();
    }

    public Task<Todo> AddTodoAsync(string title)
    {
        var newTodo = new Todo
        {
            Title = title,
            IsDone = false,
        };
        return todoRepository.AddTodoAsync(newTodo);
    }

    public Task UpdateTodoTitleAsync(Todo todo, string title)
    {
        var newTodo = todo with
        {
            Title = title,
        };
        return todoRepository.UpdateTodoAsync(newTodo);
    }

    public Task UpdateTodoIsDoneAsync(Todo todo, bool isDone)
    {
        var newTodo = todo with
        {
            IsDone = isDone,
        };
        return todoRepository.UpdateTodoAsync(newTodo);
    }
}
