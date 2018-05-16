using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerSide.BLL.DTO;
using ServerSide.DAL;
using ServerSide.DAL.Models;

namespace ServerSide.Controllers
{
    [Produces("application/json")]
    [Route("api/Todo")]
    public class TodoController : Controller
    {
        private readonly TaskListContext _dbContext;

        public TodoController(TaskListContext context)
        {
            _dbContext = context;
        }

        // GET: api/Todo
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _dbContext.Todo.ToListAsync());
        }

        //// GET: api/Todo/5
        //[HttpGet("{id}", Name = "Get")]
        //public async Task<IAsyncResult> Get(int id)
        //{ 
           
        //    return;
        //}
        
        // POST: api/Todo
        [HttpPost]
        public void Post([FromBody]TodoDto value)
        {

        }
        
        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
