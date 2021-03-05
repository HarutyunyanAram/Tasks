using AutoMapper;

namespace VS.Task.Business.Mappers
{
    public class ProviderMapper : Profile
    {
        public ProviderMapper()
        {
            CreateMap<Data.Entities.Provider, Models.Provider>();

            CreateMap<Models.Provider, Data.Entities.Provider>();
        }
    }
}
