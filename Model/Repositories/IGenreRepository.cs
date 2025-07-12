using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;

namespace APIVideogames.Model.Repositories
{
    public interface IGenreRepository
    {
        Task<bool> DeleteGenre(Genre genre);
        Task<Genre?> GetGenreById(int id);
        Genre GetGenreCreation(GenreCreationDto genreCreationDto);
        GenreDto GetGenreDto(Genre genre);
        Task<IEnumerable<GenreDto>> GetGenres();
        Task<bool> PostGenre(Genre genre);
        Task<bool> PutGenre(Genre genre);
    }
}
