using System;
using System.Collections.Generic;
using ServerSide.BLL.DTO;
using ServerSide.BLL.Services.Interfaces;
using ServerSide.DAL.UnitOfWork;

namespace ServerSide.BLL.Services
{
    public class TodoService : ITodoService
    {
        private readonly UnitOfWork _unitOfWork;

        public TodoService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public TodoDto GetTodoById(int todoId)
        {
            var item = _unitOfWork.TodoRepository.GetById(todoId);
            if (item != null)
            {

            }

            return null;
        }

        public IEnumerable<TodoDto> GetAllTodos()
        {
            throw new NotImplementedException();
        }

        public int CreateTodo(TodoDto todoItem)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTodo(int todoId, TodoDto todoOldItem)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTodo(int todoId)
        {
            throw new NotImplementedException();
        }
    }
}
