/* using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace  ToDoList.Models {
    public class TodoListContext : DbContext {
        public TodoListContext() { }
        public TodoListContext(DbContextOptions<TodoListContext> options) : base (options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<MyTask> MyTasks { get; set; }
    }
} */
