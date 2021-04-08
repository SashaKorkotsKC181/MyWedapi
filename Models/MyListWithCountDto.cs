using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Models
{
    public class MyListWithCountDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CountOfNoDoneTasks { get; set; }
        
    }
}