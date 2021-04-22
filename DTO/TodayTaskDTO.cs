using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoList.Models
{
    public class TodayTaskDTO
    {
        public int MyListId { get; set; }
        public string TitleOfList { get; set; }
        public int MyTaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DoDate { get; set; }
        public bool Done { get; set; }
        
    }
}