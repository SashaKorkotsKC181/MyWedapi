using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class MyTask
    {
        public int MyTaskId { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? DoDate { get; set; }
        public bool Done { get; set; }
        public int MyListId { get; set; }
        public MyList MyList { get; set; }

    }
}
