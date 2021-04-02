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
        public Dictionary<int, MyTask> GetAll()
        {
            return tasks;
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
            tasks.Add(++lastIndex,todoItem);

            return todoItem;
        }
        public bool IsContainsId(int id)
        {
            return tasks.ContainsKey(id);
        } 
    }

}