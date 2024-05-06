using System.Data.Common;
using BlazorHybrid.Model.Entities;
using BlazorHybrid.Model.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace BlazorHybrid.Model.Impl;

public class TodoRepository(TodoContext context) : ITodoRepository
{
    public Task<Todo[]> GetTodosAsync()
    {
        return Task.Run(() => context.Todos.ToArray());
    }

    public async Task<Todo> AddTodoAsync(Todo todo)
    {
        var newTodo = await context.AddAsync(todo);
        await context.SaveChangesAsync();
        return newTodo.Entity;
    }

    public async Task UpdateTodoAsync(Todo todo)
    {
        if (await context.Todos.FindAsync(todo.Id) is Todo oldTodo)
        {
            context.Entry(oldTodo).State = EntityState.Detached;
            context.Update(todo);
            await context.SaveChangesAsync();
        }
    }

    public async Task RemoveTodoAsync(Todo todo)
    {
        if (await context.Todos.FindAsync(todo.Id) is Todo oldTodo)
        {
            context.Remove(oldTodo);
            await context.SaveChangesAsync();
        }
    }
}
