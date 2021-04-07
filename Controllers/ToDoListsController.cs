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
        public ActionResult<IEnumerable<MyList>> GetMyLists()
        {
            // TODO: Your code here

            return Ok(service.GetAllLists());
        }
        [HttpGet("{id}")]
        public ActionResult<MyList> GetMyTasks(int id)
        {
            // TODO: Your code here

            return Ok(service.GetAllTaskFromList(id));
        }
        [HttpPost("")]
        public ActionResult<MyList> PostMyList(MyList myList)
        {                        
            return Ok(service.AddList(myList));
        }
        [HttpPost("{id}")]
        public ActionResult<MyTask> PostMyTask(int id, MyTask model)
        {                        
            return Ok(service.AddTask(id,model));
        }

        [HttpPatch("{idList}")]
        public ActionResult<MyList> PatchMyList(int idList, MyList model)
        {
            // TODO: Your code her
            
            return Ok(service.UpdateList(idList, model));
        }
        [HttpPatch("{idList}/{idTask}")]
        public ActionResult<MyTask> PutMyList(int idList, int idTask, MyTask model)
        {
            // TODO: Your code her

            return Ok(service.UpdateTask(idList, idTask, model));
        }
        [HttpDelete("{id}")]
        public ActionResult<MyList> DeleteMyListById(int id)
        {
            // TODO: Your code here            
            

            return service.DeleteList(id);
        }
        [HttpDelete("{idList}/{idTask}")]
        public ActionResult<MyTask> DeleteMyListById(int idList, int idTask)
        {
            // TODO: Your code here            

            return service.DeleteTask(idList, idTask);
        }
    }
}