using APIVideogames.Model.Entities;

namespace APIVideogames.Model.Repositories
{
    public interface IVideogameRepository
    {
        Task<bool> PostVideogame(Videogame videogame);
        Task<bool> PlatformExist(Videogame videogame);
        Task<IEnumerable<Videogame>> GetVideogames();
        Task<Videogame?> GetVideogameById(int id);
        Task<bool> PutVideogame(int id, Videogame videogame);
        Task<bool> DeleteVideogame(Videogame videogame);
    }
}
