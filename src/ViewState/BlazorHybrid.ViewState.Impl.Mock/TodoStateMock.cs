// using BlazorHybrid.Model.Entities;

// namespace BlazorHybrid.ViewState.Impl.Mock;

// public class TodoStateMock : ITodoState
// {
//     public List<Todo>? Todos { get; private set; }

//     public string? NewTodoTitle { get; set; }

//     public async Task LoadTodos()
//     {
//         await Task.Delay(500);

//         Todos = [
//             new Todo {
//                 Title = "あいうえお",
//                 IsDone = false,
//             },
//             new Todo {
//                 Title = "かきくけこ",
//                 IsDone = true,
//             }
//         ];
//     }

//     public async Task AddTodo()
//     {
//         throw new NotImplementedException();
//     }

//     public async Task UpdateTodo(Todo todo)
//     {
//         throw new NotImplementedException();
//     }
// }
