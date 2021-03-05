using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using VS.Task.Business.Models;
using VS.Task.Business.Services.Contracts;
using VS.Task.Data.Repositories.Contracts;
using VS.Task.Data.Repositories.Specifications;

namespace VS.Task.Business.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        public GroupService(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<Group> Create(Group group)
        {
            var result = await _groupRepository.Add(_mapper.Map<Group, Data.Entities.Group>(group));

            return _mapper.Map<Data.Entities.Group, Group>(result);
        }

        public async System.Threading.Tasks.Task Delete(long id)
        {
            var result = await _groupRepository.GetById(id);

            await _groupRepository.Delete(result);
        }

        public async Task<Group> GetById(long groupId)
        {
            var group = await _groupRepository.GetSingleBySpec(new GroupSpecification(groupId));

            return _mapper.Map<Data.Entities.Group, Group>(group);
        }

        public async Task<IEnumerable<Group>> List()
        {
            var groups = await _groupRepository.List();

            return _mapper.Map<IEnumerable<Data.Entities.Group>, IEnumerable<Business.Models.Group>>(groups); 
        }

        public async System.Threading.Tasks.Task Update(Group group)
        {
            await _groupRepository.Update(_mapper.Map<Group, Data.Entities.Group>(group));
        }
    }
}
