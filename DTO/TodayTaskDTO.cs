using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Models
{
    public class TodayTaskDTO
    {
        public string listName { get; set; }
        public MyTask task { get; set; }
        
    }
}