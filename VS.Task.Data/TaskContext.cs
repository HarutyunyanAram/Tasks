using Microsoft.EntityFrameworkCore;
using VS.Task.Data.Entities;

namespace VS.Task.Data
{
    public class TaskContext : DbContext
    {
        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
        }

        public DbSet<Group> Groups { get; set;}
        public DbSet<Provider> Providers { get; set; }
    }
}
