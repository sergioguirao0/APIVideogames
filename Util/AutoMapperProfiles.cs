using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;
using AutoMapper;

namespace APIVideogames.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Platform, PlatformDto>();
            CreateMap<PlatformCreationDto, Platform>();
        }
    }
}
