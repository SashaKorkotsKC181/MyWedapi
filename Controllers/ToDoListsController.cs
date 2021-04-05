using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using MyWedapi;

namespace ToDoLists.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListsController : ControllerBase
    {
        private ToDoListsServices service;

        public ToDoListsController(ToDoListsServices service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public ActionResult<Dictionary<int, Dictionary<int, MyTask>>> GetMyTasks()
        {
            // TODO: Your code here

            return service.GetAllLists();
        }

        [HttpGet("{id}/tasks")]
        public ActionResult<Dictionary<int, MyTask>> GetListById(int id)
        {
            // TODO: Your code here            

            if (service.IsContainsId(id))
            {
                return service.GetAllFromList(id);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("/tasks")]
        public ActionResult<Dictionary<int, MyTask>> GetFromListMyTaskById()
        {
            int id = Convert.ToInt32(this.Request.Query["listId"]);
            // TODO: Your code here            
            if (service.IsContainsId(id))
            {
                return service.GetAllFromList(id);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpPost("")]
        public async Task<ActionResult<MyTask>> PostMyTask(MyTask model)
        {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMyTask(int id, MyTask model)
        {
            // TODO: Your code here
            await Task.Yield();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MyTask>> DeleteMyTaskById(int id)
        {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }
    }
}