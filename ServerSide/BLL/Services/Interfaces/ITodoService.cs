using System.Collections.Generic;
using ServerSide.BLL.DTO;

namespace ServerSide.BLL.Services.Interfaces
{
    public interface ITodoService
    {
        TodoDto GetTodoById(int todoId);
        IEnumerable<TodoDto> GetAllTodos();
        int CreateTodo(TodoDto todoItem);
        bool UpdateTodo(int todoOldId, TodoDto todoNewItem);
        bool DeleteTodo(int todoId);
    }
}
