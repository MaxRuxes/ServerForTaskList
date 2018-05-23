using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using AutoMapper;
using ServerSide.BLL.DTO;
using ServerSide.BLL.Services.Interfaces;
using ServerSide.DAL.Models;
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

        /// <summary>
        /// Fetches todo details by id
        /// </summary>
        /// <param name="todoId"></param>
        /// <returns></returns>
        public TodoDto GetTodoById(int todoId)
        {
            var item = _unitOfWork.TodoRepository.GetById(todoId);
            if (item != null)
            {
                var itemModel = Mapper.Map<Todo, TodoDto>(item);
                return itemModel;
            }

            return null;
        }

        public IEnumerable<TodoDto> GetAllTodos()
        {
            var todos = _unitOfWork.TodoRepository.GetAll().ToList();
            if (todos.Any())
            {
                var todoModel = Mapper.Map<List<Todo>, List<TodoDto>>(todos);
                return todoModel;
            }

            return null;
        }

        public int CreateTodo(TodoDto todoItem)
        {
            using (var scope = new TransactionScope())
            {
                var todo = new Todo
                {
                    Heading = todoItem.Heading
                };

                _unitOfWork.TodoRepository.Create(todo);
                _unitOfWork.Save();
                scope.Complete();

                return todo.Id;
            }
        }

        public bool UpdateTodo(int todoOldId, TodoDto todoNewItem)
        {
            var success = false;
            if (todoNewItem != null)
            {
                using (var scope = new TransactionScope())
                {
                    var todo = _unitOfWork.TodoRepository.GetById(todoOldId);
                    if (todo != null)
                    {
                        todo.DateCreate = todoNewItem.DateCreate;
                        todo.Heading = todoNewItem.Heading;
                        todo.Text = todoNewItem.Text;

                        _unitOfWork.TodoRepository.Update(todo);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }

            return success;
        }

        public bool DeleteTodo(int todoId)
        {
            var success = false;
            if (todoId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var todo = _unitOfWork.TodoRepository.GetById(todoId);
                    if (todo != null)
                    {
                        _unitOfWork.TodoRepository.Remove(todo);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }

            return success;
        }
    }
}
