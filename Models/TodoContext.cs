using Microsoft.EntityFrameworkCore;

namespace TodoApp.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {

        }
        public DbSet<TodoApp.Models.TodoItem> TodoItems { get; set; }

        public DbSet<TodoApp.Models.User> Users { get; set; }
    }
}