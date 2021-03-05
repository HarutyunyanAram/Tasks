using AutoMapper;

namespace VS.Task.Business.Mappers
{
    public class GroupMapper : Profile
    {
        public GroupMapper()
        {
            CreateMap<Data.Entities.Group, Models.Group>();

            CreateMap<Models.Group, Data.Entities.Group>();
        }
    }
}
