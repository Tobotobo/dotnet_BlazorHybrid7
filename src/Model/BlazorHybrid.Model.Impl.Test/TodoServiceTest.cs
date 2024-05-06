using System.Runtime.CompilerServices;
using BlazorHybrid.Model.Entities;
using BlazorHybrid.Model.Impl.Mock;

namespace BlazorHybrid.Model.Impl.Test;

public class TodoServiceTest
{
    private TodoService? _target;
    TodoService Target { get => _target ?? throw new NullReferenceException(); }

    [SetUp]
    public void Setup()
    {
        _target = new TodoService(
            new TodoRepositoryMock()
        );
    }

    [Test]
    public async Task GetTodosAsync()
    {
        var result = await Target.GetTodosAsync();
        Assert.That(result, Has.Length.EqualTo(0));
    }

    [Test]
    public async Task AddTodoAsync()
    {
        var title = "とてちてた";
        var actual1 = await Target.AddTodoAsync(title);
        Assert.That(actual1.Id, Is.EqualTo(1));
        Assert.That(actual1.Title, Is.EqualTo(title));
        Assert.That(actual1.IsDone, Is.False);
        var actual2 = await Target.GetTodosAsync();
        Assert.That(actual2, Has.Length.EqualTo(1));
        Assert.That(actual2[0], Is.EqualTo(actual1));
    }

    [Test]
    public async Task UpdateTodoTitleAsync()
    {
        var newTodo = await Target.AddTodoAsync("とてちてた");
        await Target.UpdateTodoTitleAsync(newTodo, "あいうえお");
        var actual = await Target.GetTodosAsync();
        Assert.That(actual, Has.Length.EqualTo(1));
        Assert.That(actual[0], Is.EqualTo(new Todo
        {
            Id = 1,
            Title = "あいうえお",
            IsDone = false,
        }));
    }

    [Test]
    public async Task UpdateTodoIsDoneAsync()
    {
        var newTodo = await Target.AddTodoAsync("とてちてた");
        await Target.UpdateTodoIsDoneAsync(newTodo, true);
        var actual = await Target.GetTodosAsync();
        Assert.That(actual, Has.Length.EqualTo(1));
        Assert.That(actual[0], Is.EqualTo(new Todo
        {
            Id = 1,
            Title = "とてちてた",
            IsDone = true,
        }));
    }
}
