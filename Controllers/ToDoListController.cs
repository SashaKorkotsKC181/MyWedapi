using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using MyWedapi;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private ToDoListServices service;

        public ToDoListController(ToDoListServices service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<MyTask>> GetTasks()
        {
            return Ok(service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<MyTask> GetTaskById(int id)
        {
            if (service.IsContainsId(id))
            {
                return service.GetMyTask(id);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("/tasks")]
        public ActionResult<MyTask> GetTaskByIdOnParam(int id)
        {
            if (service.IsContainsId(id))
            {
                return service.GetMyTask(id);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("")]
        public ActionResult<MyTask> PostTask(MyTask model)
        {
            MyTask currentTask = service.AddTask(model);
            return Created($"api/ToDoList/{service.lastIndex}", currentTask);
        }

        [HttpPut("{id}")]
        public IActionResult PutTask(int id, MyTask model)
        {
            // TODO: Your code here
            if (service.IsContainsId(id))
            {
                return Ok(service.Ubdate(id,model));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<MyTask> DeleteTaskById(int id)
        {
            // TODO: Your code here            
            if (service.IsContainsId(id))
            {
                return Ok(service.DeleteById(id));
            }
            else
            {
                return NotFound();
            }
        }
    }
}