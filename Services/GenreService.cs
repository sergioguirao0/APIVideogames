using APIVideogames.Data;
using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;
using APIVideogames.Model.Repositories;
using APIVideogames.Resources.Strings;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIVideogames.Services
{
    public class GenreService(ApplicationDbContext context, ILogger<GenreService> logger, IMapper mapper) : IGenreRepository
    {
        private readonly ApplicationDbContext context = context;
        private readonly ILogger<GenreService> logger = logger;
        private readonly IMapper mapper = mapper;

        public async Task<bool> PostGenre(Genre genre)
        {
            try
            {
                context.Add(genre);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(ApiStrings.PostGenreError + e.Message);
                return false;
            }
        }

        public Genre GetGenreCreation(GenreCreationDto genreCreationDto)
        {
            return mapper.Map<Genre>(genreCreationDto);
        }

        public async Task<IEnumerable<GenreDto>> GetGenres()
        {
            var genres = await context.Genres.ToListAsync();
            var genresDto = mapper.Map<IEnumerable<GenreDto>>(genres);
            return genresDto;
        }

        public async Task<Genre?> GetGenreById(int id)
        {
            return await context.Genres
                .Include(genre => genre.Videogames)
                .FirstOrDefaultAsync(genre => genre.Id == id);
        }

        public GenreDto GetGenreDto(Genre genre)
        {
            return mapper.Map<GenreDto>(genre);
        }

        public async Task<bool> PutGenre(Genre genre)
        {
            try
            {
                context.Update(genre);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(ApiStrings.PutGenreError + e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteGenre(Genre genre)
        {
            try
            {
                context.Remove(genre);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(ApiStrings.DeleteGenreError + e.Message);
                return false;
            }
        }
    }
}
