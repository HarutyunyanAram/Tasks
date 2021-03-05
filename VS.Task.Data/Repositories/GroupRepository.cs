using VS.Task.Data.Entities;
using VS.Task.Data.Repositories.Contracts;
using VS.Task.Data.Common;

namespace VS.Task.Data.Repositories
{
    public sealed class GroupRepository : CommonRepository<long, Group>, IGroupRepository
    {
        public GroupRepository(TaskContext appContext) : base(appContext)
        {
        }
    }
}
