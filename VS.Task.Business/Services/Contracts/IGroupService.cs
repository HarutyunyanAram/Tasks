using System.Collections.Generic;
using System.Threading.Tasks;
using VS.Task.Business.Models;

namespace VS.Task.Business.Services.Contracts
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> List();

        Task<Group> GetById(long groupId);

        Task<Group> Create(Group group);

        System.Threading.Tasks.Task Update(Group group);
        
        System.Threading.Tasks.Task Delete(long id);
    }
}
