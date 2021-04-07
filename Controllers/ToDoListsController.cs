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

        /* [HttpGet("")]
        public ActionResult<IEnumerable<MyTask>> GetMyTasks()
        {
            // TODO: Your code here

            //return service.GetAllLists();
        } */

        [HttpGet("/lists/{listId}/tasks")]
        public ActionResult<IEnumerable<MyTask>> GetListById(int listId)
        {
            // TODO: Your code here            

            if (service.IsContainsId(listId))
            {
                return Ok(service.GetAllFromList(listId));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("/tasks")]
        public ActionResult<IEnumerable<MyTask>> GetFromListMyTaskById()
        {
            int id = Convert.ToInt32(this.Request.Query["listId"]);
            // TODO: Your code here            
            if (service.IsContainsId(id))
            {
                return Ok(service.GetAllFromList(id));
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
        public async Task<IActionResult> PutMyList(int id, MyTask model)
        {
            // TODO: Your code here
            await Task.Yield();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MyTask>> DeleteMyListById(int id)
        {
            // TODO: Your code here            
            await Task.Yield();

            return NoContent();
        }
    }
}