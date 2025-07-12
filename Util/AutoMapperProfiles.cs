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
            CreateMap<Platform, PlatformWithVideogamesDto>();
            CreateMap<PlatformCreationDto, Platform>();

            CreateMap<DeveloperCreationDto, Developer>();
            CreateMap<Developer, DeveloperDto>();

            CreateMap<GenreCreationDto, Genre>();
            CreateMap<Genre, GenreDto>();

            CreateMap<VideogameCreationDto, Videogame>();
            CreateMap<Videogame, VideogameDto>();
            CreateMap<Videogame, VideogamePatchDto>().ReverseMap();

            CreateMap<Videogame, VideogameDataDto>()
                .ForMember(dto => dto.Platform, config => config.MapFrom(ent => ent.Platform!.Name))
                .ForMember(dto => dto.Developer, config => config.MapFrom(ent => ent.Developer!.Name))
                .ForMember(dto => dto.Genre, config => config.MapFrom(ent => ent.Genre!.Name));

            CreateMap<ComentaryCreationDto, Comentary>();
            CreateMap<Comentary, ComentaryDto>();
            CreateMap<Comentary, ComentaryPatchDto>().ReverseMap();
        }
    }
}
