using VS.Task.Data.Common;
using VS.Task.Data.Entities;
using VS.Task.Data.Repositories.Contracts;

namespace VS.Task.Data.Repositories
{
    public class ProviderRepository : CommonRepository<long, Provider>, IProviderRepository
    {
        public ProviderRepository(TaskContext appContext):base(appContext)
        {
        }
     }
}
