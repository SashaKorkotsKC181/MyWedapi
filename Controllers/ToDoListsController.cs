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
        
        [HttpGet("collection/today")]
        public ActionResult<IEnumerable<MyList>> GetMyListsWithTasks()
        {
            // TODO: Your code here

            return Ok(service.GetMyListsWithTasks());
        }


        [HttpGet("dashboard")]
        public ActionResult<DashboardDto> GetToday()
        {
            // TODO: Your code here

            return Ok(service.GetTodayTasks());
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<MyList>> GetMyLists()
        {
            // TODO: Your code here

            return Ok(service.GetAllLists());
        }
        [HttpGet("{id}")]
        public ActionResult<MyList> GetMyList(int id)
        {
            // TODO: Your code here

            return Ok(service.GetList(id));
        }

        [HttpGet("{idList}{idTask}")]
        public ActionResult<MyTask> GetMyTask(int idList, int idTask)
        {
            // TODO: Your code here

            return Ok(service.GetTask(idList, idTask));
        }

        [HttpGet("/lists/{id}/tasks")]
        public ActionResult<MyList> GetMyTasks(int id, bool isAll)
        {
            // TODO: Your code here

            return Ok(service.GetAllTaskFromList(id,isAll));
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

        [HttpPut("{idList}")]
        public ActionResult<MyList> PutMyList(int idList, MyList model)
        {
            // TODO: Your code her
            
            return Ok(service.UpdateList(idList, model));
        }
        [HttpPut("{idList}/{idTask}")]
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