using AutoMapper;
using InventoryManagementSystemAPI.Data.Models;
using InventoryManagementSystemAPI.Data.Models.DTOs;

namespace InventoryManagementSystemAPI.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, PublicUserViewModel>();
            CreateMap<Register, User>();
            CreateMap<Item, ItemDto>().ForMember(x => x.User, opt=> opt.MapFrom(src => src.User));

            CreateMap<User, UserItemDto>();
            CreateMap<ItemDto, Item>();

            CreateMap<User, UserProfileDto>().ForMember(x => x.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
}