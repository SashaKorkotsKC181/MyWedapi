using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace  ToDoList.Models {
    public class TodoListsContext : DbContext {
        public TodoListsContext() { }
        public TodoListsContext(DbContextOptions<TodoListsContext> options) : base (options) { }

        public DbSet<MyTask> MyTasks { get; set; }
        public DbSet<MyList> MyLists { get; set; }
    }
}