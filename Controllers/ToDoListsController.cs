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

        [HttpGet("lists")]
        public ActionResult<IEnumerable<MyList>> GetMyLists()
        {
            // TODO: Your code here

            return Ok(service.GetAllLists());
        }
        [HttpGet("list/{id}")]
        public ActionResult<MyList> GetMyList(int id)
        {
            // TODO: Your code here

            return Ok(service.GetList(id));
        }

        [HttpGet("list/{idList}/task/{idTask}")]
        public ActionResult<MyTask> GetMyTask(int idList, int idTask)
        {
            // TODO: Your code here

            return Ok(service.GetTask(idList, idTask));
        }

        [HttpGet("lists/{id}/tasks")]
        public ActionResult<MyList> GetMyTasks(int id, bool isAll)
        {
            // TODO: Your code here

            return Ok(service.GetAllTaskFromList(id,isAll));
        }
        [HttpPost("list")]
        public ActionResult<MyList> PostMyList(MyList myList)
        {                        
            return Ok(service.AddList(myList));
        }
        [HttpPost("list/{id}/task")]
        public ActionResult<MyTask> PostMyTask(int id, MyTask model)
        {                        
            return Ok(service.AddTask(id,model));
        }

        [HttpPost("list/{idList}")]
        public ActionResult<MyList> PostMyList(int idList, MyList model)
        {
            // TODO: Your code her
            
            return Ok(service.UpdateList(idList, model));
        }
        [HttpPost("list/{idList}/task/{idTask}")]
        public ActionResult<MyTask> PostMyTask(int idList, int idTask, MyTask model)
        {
            // TODO: Your code her

            return Ok(service.UpdateTask(idList, idTask, model));
        }
        [HttpDelete("list/{id}")]
        public ActionResult<MyList> DeleteMyListById(int id)
        {
            // TODO: Your code here            
            

            return service.DeleteList(id);
        }
        [HttpDelete("list/{idList}/task/{idTask}")]
        public ActionResult<MyTask> DeleteMyListById(int idList, int idTask)
        {
            // TODO: Your code here            

            return service.DeleteTask(idList, idTask);
        }


    }
}