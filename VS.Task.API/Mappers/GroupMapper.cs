using AutoMapper;

namespace VS.Task.API.Mappers
{
    public class GroupMapper : Profile
    {
        public GroupMapper()
        {
            CreateMap<Business.Models.Group, ViewModels.Group.Response.GroupResponse>();

            CreateMap<Business.Models.Group, ViewModels.Group.Response.GroupListResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));

            CreateMap<ViewModels.Group.Request.CreateGroupRequest, Business.Models.Group>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));

            CreateMap<ViewModels.Group.Request.UpdateGroupRequest, Business.Models.Group>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
        }
    }
}
