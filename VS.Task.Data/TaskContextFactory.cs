using Microsoft.EntityFrameworkCore;

namespace VS.Task.Data
{
    public class TaskContextFactory : DesignTimeDbContextFactoryBase<TaskContext>
    {
        protected override TaskContext CreateNewInstance(DbContextOptions<TaskContext> options)
        {
            return new TaskContext(options);
        }
    }
}
