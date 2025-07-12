using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;

namespace APIVideogames.Model.Repositories
{
    public interface IVideogameRepository
    {
        Task<bool> PostVideogame(Videogame videogame);
        Task<bool> PlatformExist(Videogame videogame);
        Task<IEnumerable<VideogameDto>> GetVideogames();
        Task<Videogame?> GetVideogameById(int id);
        Task<bool> PutVideogame(Videogame videogame);
        Task<bool> DeleteVideogame(Videogame videogame);
        Videogame GetVideogameCreation(VideogameCreationDto videogameCreationDto);
        Task<bool> DeveloperExist(Videogame videogame);
        Task<bool> GenreExist(Videogame videogame);
        VideogameDto GetVideogameDto(Videogame videogame);
    }
}
