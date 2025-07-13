using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;

namespace APIVideogames.Model.Repositories
{
    public interface IVideogameRepository
    {
        Task<bool> PostVideogame(Videogame videogame);
        Task<List<int>> PlatformExist(VideogameCreationDto videogameCreationDto);
        Task<IEnumerable<VideogameDto>> GetVideogames();
        Task<Videogame?> GetVideogameById(int id);
        Task<bool> PutVideogame();
        Task<bool> DeleteVideogame(Videogame videogame);
        Videogame GetVideogameCreation(VideogameCreationDto videogameCreationDto);
        Task<bool> DeveloperExist(Videogame videogame);
        Task<bool> GenreExist(Videogame videogame);
        VideogameDataDto GetVideogameDto(Videogame videogame);
        VideogamePatchDto GetPatchVideogame(Videogame videogame);
        Task<bool> PatchVideogame(VideogamePatchDto videogamePatchDto, Videogame videogame);
        void VideogamePlatformOrder(Videogame videogame);
        Task<List<Platform>> GetPlatformsByIds(List<int> platformIds);
    }
}
