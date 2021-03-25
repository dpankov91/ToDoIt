using Microsoft.EntityFrameworkCore;
using Model;

namespace DAL
{
    public class TodoContext : DbContext
    {

        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        { }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Assignee> Assignees { get; set; }

    }
}