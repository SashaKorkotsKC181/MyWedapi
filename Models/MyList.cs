using System;
using System.Collections.Generic;

namespace ToDoList.Models
{
    public class MyList
    {
        public int MyListId { get; set; }         
        public string Title { get; set; }
        public List<MyTask> Tasks { get; set; }

    }
}