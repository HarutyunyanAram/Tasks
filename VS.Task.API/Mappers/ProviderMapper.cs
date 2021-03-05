using AutoMapper;

namespace VS.Task.API.Mappers
{
    public class ProviderMapper : Profile
    {
        public ProviderMapper()
        {
            CreateMap<Business.Models.Provider, ViewModels.Provider.Response.ProviderResponse>();

            CreateMap<Business.Models.Provider, ViewModels.Provider.Response.ProviderListResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));

            CreateMap<ViewModels.Provider.Request.CreateProviderRequest, Business.Models.Provider>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));

            CreateMap<ViewModels.Provider.Request.UpdateProviderRequest, Business.Models.Provider>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId));
        }
    }
}
