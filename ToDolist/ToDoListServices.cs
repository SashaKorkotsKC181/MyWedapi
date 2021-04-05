using System.Collections.Generic;
using ToDoList.Models;

namespace MyWedapi
{
    public class ToDoListServices
    {
        private Dictionary<int, MyTask> tasks = new Dictionary<int, MyTask>()
        {
            {1 ,new MyTask() {/* Id = 1 ,*/Title ="make class"}},
            {2 ,new MyTask() {/* Id = 2, */Title ="make struct"}}
        };
        
        public int lastIndex = 2;
        public IEnumerable<MyTask> GetAll()
        {
            return tasks.Values;
        }
        public MyTask GetMyTask(int id)
        {
            return tasks[id];
        }
        public MyTask AddTask(MyTask model)
        {
            MyTask todoItem = new MyTask
            {
                /* Id = ++lastIndex, */
                Title = model.Title,
                Done = model.Done,
                Description = model.Description
            };
            tasks.Add(++lastIndex, todoItem);

            return todoItem;
        }
        public bool IsContainsId(int id)
        {
            return tasks.ContainsKey(id);
        }
        public MyTask DeleteById(int id)
        {
            MyTask deletedTask = tasks[id];
            tasks.Remove(id);
            return deletedTask;
        }
        public MyTask Ubdate(int id, MyTask newTask)
        {
            MyTask task = new MyTask()
            {
                Title = newTask.Title != null ? newTask.Title:tasks[id].Title,
                Description = newTask.Description != null ? newTask.Description:tasks[id].Description,
                DoDate = newTask.DoDate != null ? newTask.DoDate:tasks[id].DoDate,
                Done = newTask.Done
            };
            tasks.Remove(id);
            tasks.Add(id,task);
            lastIndex--;
            return task;
        }
    }

}