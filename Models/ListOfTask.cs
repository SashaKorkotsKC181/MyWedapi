using System;
using System.Collections.Generic;

namespace ToDoList.Models
{
    public class ListsOfTasks
    {
        public int Id { get; set; }         
        public List<MyTask> Tasks { get; set; }

    }
}