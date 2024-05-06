using BlazorHybrid.Model.Entities;
using BlazorHybrid.Model.Impl.Mock;
using BlazorHybrid.Model.Interfaces;
using Moq;

namespace BlazorHybrid.ViewState.Impl.Test;

public class TodoStateTest
{
    TodoState? _state;
    TodoState State { get => _state ?? throw new NullReferenceException(); }

    [SetUp]
    public void Setup()
    {
        _state = new TodoState(new TodoServiceMock());
    }

    [Test]
    public void 初期値()
    {
        var result = State.Todos;
        Assert.That(result, Is.Null);
    }

    [Test]
    public async Task LoadTodos()
    {
        await State.LoadTodos();
        Assert.That(State.Todos, Has.Length.EqualTo(0));
    }

    [Test]
    public async Task AddTodo()
    {
        State.NewTodoTitle = "あいうえお";
        await State.AddTodo();
        Assert.That(State.Todos, Has.Length.EqualTo(1));
        var todo = State.Todos![0];
        Assert.That(todo.Id, Is.EqualTo(1));
        Assert.That(todo.Title, Is.EqualTo("あいうえお"));
        Assert.That(todo.IsDone, Is.False);
    }

    [Test]
    public async Task UpdateTodoTitle()
    {
        State.NewTodoTitle = "あいうえお";
        await State.AddTodo();
        await State.UpdateTodoTitle(State.Todos![0], "かきくけこ");
        var todo = State.Todos![0];
        Assert.That(todo.Id, Is.EqualTo(1));
        Assert.That(todo.Title, Is.EqualTo("かきくけこ"));
        Assert.That(todo.IsDone, Is.False);
    }

    [Test]
    public async Task UpdateTodoIsDone()
    {
        State.NewTodoTitle = "あいうえお";
        await State.AddTodo();
        await State.UpdateTodoIsDone(State.Todos![0], true);
        var todo = State.Todos![0];
        Assert.That(todo.Id, Is.EqualTo(1));
        Assert.That(todo.Title, Is.EqualTo("あいうえお"));
        Assert.That(todo.IsDone, Is.True);
    }
}
