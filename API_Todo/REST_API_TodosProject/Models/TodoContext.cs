using Microsoft.EntityFrameworkCore;

namespace REST_API_TodosProject.Models
{
    public class TodoContext: DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }
        public DbSet<TodoItem> TodoItems { get; set; } = null!;
    }
}
