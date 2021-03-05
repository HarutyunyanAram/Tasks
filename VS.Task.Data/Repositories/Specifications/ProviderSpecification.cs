using VS.Task.Data.Common;
using VS.Task.Data.Entities;

namespace VS.Task.Data.Repositories.Specifications
{
    public sealed class ProviderSpecification : BaseSpecification<Provider>
    {
        public ProviderSpecification(long groupId) 
            : base(p => p.GroupId == groupId)
        {
        }
    }
}
