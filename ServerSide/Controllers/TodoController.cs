using Microsoft.AspNetCore.Mvc;
using ServerSide.BLL.DTO;
using ServerSide.BLL.Services;
using ServerSide.BLL.Services.Interfaces;
using ServerSide.DAL;

namespace ServerSide.Controllers
{
    [Produces("application/json")]
    [Route("api/Todo")]
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(TaskListContext context)
        {
            _todoService = new TodoService();
        }

        // GET: api/Todo
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_todoService.GetAllTodos());
        }

        // GET: api/Todo/5
        [HttpGet("{id}", Name = "GetAll")]
        public IActionResult GetAll(int id)
        {
            return Ok(_todoService.GetTodoById(id));
        }

        // POST: api/Todo
        [HttpPost]
        public int Post([FromBody] TodoDto value)
        {
            return _todoService.CreateTodo(value);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody] TodoDto value)
        {
            if (id > 0)
            {
                return _todoService.UpdateTodo(id, value);
            }

            return false;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            if (id > 0)
            {
                return _todoService.DeleteTodo(id);
            }

            return false;
        }
    }
}