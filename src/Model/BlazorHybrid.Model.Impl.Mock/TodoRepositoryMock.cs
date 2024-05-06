using BlazorHybrid.Model.Entities;
using BlazorHybrid.Model.Interfaces;

namespace BlazorHybrid.Model.Impl.Mock;

public class TodoRepositoryMock : ITodoRepository
{
    readonly object _lock = new();
    readonly List<Todo> _todos = [];
    int _lastId = 0;

    public Task<Todo[]> GetTodosAsync()
    {
        lock (_lock)
        {
            return Task.FromResult(_todos.ToArray());
        }
    }

    public Task UpdateTodoAsync(Todo todo)
    {
        return Task.Run(() =>
        {
            lock (_lock)
            {
                var index = _todos.FindIndex(x => x.Id == todo.Id);
                if (index == -1)
                {
                    throw new InvalidOperationException("Todo item not found.");
                }
                _todos[index] = todo;
            }
        });
    }

    public Task<Todo> AddTodoAsync(Todo todo)
    {
        return Task.Run(() =>
        {
            _lastId += 1;
            var newTodo = todo with { Id = _lastId };
            lock (_lock)
            {
                _todos.Add(newTodo);
            }
            return newTodo;
        });
    }

    public Task RemoveTodoAsync(Todo todo)
    {
        return Task.Run(() =>
        {
            lock (_lock)
            {
                var index = _todos.FindIndex(x => x.Id == todo.Id);
                if (index == -1)
                {
                    throw new InvalidOperationException("Todo item not found.");
                }
                _todos.RemoveAt(index);
            }
        });
    }
}
