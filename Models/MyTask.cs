using System;

namespace ToDoList.Models
{
    public class MyTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DoDate { get; set; }
        public bool Done { get; set; }
        /* public int Id { get; set; }
        public ListsOfTasks currentListsOfTasks { get; set; }
 */
    }
}
