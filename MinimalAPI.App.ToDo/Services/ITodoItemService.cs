using MinimalAPI.App.ToDo.Models.Entities;

namespace MinimalAPI.App.ToDo.Services
{
    public interface ITodoItemService
    {
        IEnumerable<TodoItem> GetAllTodoItems();
        IEnumerable<TodoItem> GetCompletedTodoItems();
        TodoItem? GetTodoItemById(int id);
        TodoItem CreateTodoItem(TodoItem item);
        bool UpdateTodoItem(int id, TodoItem item);
        bool DeleteTodoItem(int id);
    }
}
