using System.Collections.Generic;
using ToDoList.Models;
using System.Linq;

namespace MyWedapi
{
    public class ToDoListServices
    {   
        public int lastIndex = 2;

        TodoListContext db;


        public ToDoListServices(TodoListContext context)
        {
            this.db = context;            
        }
        public IEnumerable<MyTask> GetAll()
        {            
            return db.MyTasks.OrderBy(b => b.Id);
        }
        public MyTask GetMyTask(int id)
        {
            return db.MyTasks.Find(id);
        }
        public MyTask AddTask(MyTask model)
        {
            MyTask todoItem = new MyTask
            {
                Title = model.Title,
                Done = model.Done,
                Description = model.Description
            };
            db.MyTasks.Add(todoItem);
            db.SaveChanges();
            return todoItem;
        }
        public bool IsContainsId(int id)
        {
            return db.MyTasks.Select(b => b.Id).Contains(id);
            
        }
        public MyTask DeleteById(int id)
        {
            MyTask deleteTask = db.MyTasks.Where(b => b.Id == id).Single();
            db.Remove(deleteTask);
            db.SaveChanges();
            return deleteTask;
        }
        public MyTask Ubdate(int id, MyTask newTask)
        {
            newTask.Id = id;

            db.Update(newTask);
            db.SaveChanges();
            return newTask;
        }
    }

}