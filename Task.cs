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

/*         public MyTask(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        } */
    }
}
