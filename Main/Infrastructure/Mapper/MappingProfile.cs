using AutoMapper;
using Entities.Dtos;

namespace Main.Infrastructure.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {  
        CreateMap<UserDtoForUpdate, ApplicationUser>().ReverseMap();  
    }
}