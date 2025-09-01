using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace Main.Infrastructure.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {  
        CreateMap<UserDtoForUpdate, ApplicationUser>().ReverseMap();  
        CreateMap<EtkinlikDto, Etkinlik>().ReverseMap();  
        CreateMap<EtkinlikDtoCreate, Etkinlik>();  
    }
}