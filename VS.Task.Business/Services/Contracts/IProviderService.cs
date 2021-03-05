using System.Collections.Generic;
using System.Threading.Tasks;
using VS.Task.Business.Models;

namespace VS.Task.Business.Services.Contracts
{
    public interface IProviderService
    {
        Task<IEnumerable<Provider>> List();

        Task<Provider> GetById(long providerId);

        Task<Provider> Create(Provider provider);

        System.Threading.Tasks.Task Update(Provider provider);

        System.Threading.Tasks.Task Delete(long id);
    }
}
