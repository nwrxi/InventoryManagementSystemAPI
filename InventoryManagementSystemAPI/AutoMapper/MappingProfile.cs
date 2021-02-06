using AutoMapper;
using InventoryManagementSystemAPI.Data.Models;

namespace InventoryManagementSystemAPI.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, PublicUserViewModel>();
        }
    }
}