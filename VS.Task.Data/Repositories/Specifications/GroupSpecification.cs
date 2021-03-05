using VS.Task.Data.Common;
using VS.Task.Data.Entities;

namespace VS.Task.Data.Repositories.Specifications
{
    public sealed class GroupSpecification : BaseSpecification<Group>
    {
        public GroupSpecification(long id) 
            : base(g => g.Id == id)
        {
            AddInclude(g => g.Providers);
        }
    }
}
