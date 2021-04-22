using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class UpdateTaskDto
    {
        public int MyTaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DoDate { get; set; }
        public bool Done { get; set; }
        public int MyListId { get; set; }
        public MyList MyList { get; set; }

    }
}
