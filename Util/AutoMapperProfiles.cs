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

            CreateMap<DeveloperCreationDto, Developer>();
            CreateMap<Developer, DeveloperDto>();

            CreateMap<GenreCreationDto, Genre>();
            CreateMap<Genre, GenreDto>();

            CreateMap<VideogameCreationDto, Videogame>();
            CreateMap<Videogame, VideogameDto>();
        }
    }
}
