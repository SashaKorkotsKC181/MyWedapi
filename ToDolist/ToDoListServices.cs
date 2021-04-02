using System.Collections.Generic;
using ToDoList.Models;

namespace MyWedapi
{
    public class ToDoListServices    
    {
        private List<MyTask> tasks = new List<MyTask>() {
            new MyTask() {Id = 1,Title ="make class"},
            new MyTask() {Id = 2,Title ="make struct"}};
        public int lastIndex = 2;
        public List<MyTask> GetAll()
        {
            return tasks;
        }
        public MyTask GetMyTask(int id)
        {
            return tasks[id - 1];
        }
        public MyTask AddTask(MyTask model)
        {
            MyTask todoItem = new MyTask
            {
                Id = ++lastIndex,
                Title = model.Title,
                Done = model.Done,
                Description = model.Description
            };
            tasks.Add(todoItem);

            return todoItem;
        }
    }
    
}