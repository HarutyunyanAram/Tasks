using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VS.Task.Business.Models;
using VS.Task.Business.Services.Contracts;
using VS.Task.Data.Repositories.Contracts;

namespace VS.Task.Business.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;
        public ProviderService(IProviderRepository providerRepository, IMapper mapper)
        {
            _providerRepository = providerRepository;
            _mapper = mapper;
        }
        
        public async Task<Provider> GetById(long providerId)
        {
            return _mapper.Map<Data.Entities.Provider, Models.Provider>(await _providerRepository.GetById(providerId));
        }

        public async Task<IEnumerable<Provider>> List()
        {
            return _mapper.Map<IEnumerable<Data.Entities.Provider>, IEnumerable<Models.Provider>>(await _providerRepository.List());
        }


        public async Task<Provider> Create(Provider provider)
        {
            var result = await _providerRepository.Add(_mapper.Map<Provider, Data.Entities.Provider>(provider));

            return _mapper.Map<Data.Entities.Provider, Provider>(result);
        }

        public async System.Threading.Tasks.Task Delete(long id)
        {
            var result = await _providerRepository.GetById(id);

            await _providerRepository.Delete(result);
        }

        public async System.Threading.Tasks.Task Update(Provider provider)
        {
            await _providerRepository.Update(_mapper.Map<Provider, Data.Entities.Provider>(provider));
        }
    }
}
