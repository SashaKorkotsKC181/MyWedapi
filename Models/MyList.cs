using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class MyList
    {
        public int MyListId { get; set; } 
        
        [Required]
        [StringLength(100)]        
        public string Title { get; set; }
        public List<MyTask> Tasks { get; set; }
    
    }
}