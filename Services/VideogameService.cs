using APIVideogames.Data;
using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;
using APIVideogames.Model.Repositories;
using APIVideogames.Resources.Strings;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIVideogames.Services
{
    public class VideogameService(ApplicationDbContext context, ILogger<VideogameService> logger, IMapper mapper) : IVideogameRepository
    {
        private readonly ApplicationDbContext context = context;
        private readonly ILogger<VideogameService> logger = logger;

        public async Task<bool> PostVideogame(Videogame videogame)
        {
            try
            {
                context.Add(videogame);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(ApiStrings.PostVideogameError + e.Message);
                return false;
            }
        }

        public Videogame GetVideogameCreation(VideogameCreationDto videogameCreationDto)
        {
            return mapper.Map<Videogame>(videogameCreationDto);
        }

        public VideogamePatchDto GetPachVideogame(Videogame videogame)
        {
            return mapper.Map<VideogamePatchDto>(videogame);
        }

        public async Task<bool> PlatformExist(Videogame videogame)
        {
            return await context.Platforms.AnyAsync(pf => pf.Id == videogame.PlatformId);
        }

        public async Task<bool> DeveloperExist(Videogame videogame)
        {
            return await context.Developers.AnyAsync(dev => dev.Id == videogame.DeveloperId);
        }

        public async Task<bool> GenreExist(Videogame videogame)
        {
            return await context.Genres.AnyAsync(gen => gen.Id == videogame.GenreId);
        }

        public async Task<IEnumerable<VideogameDto>> GetVideogames()
        {
            var videogames = await context.Videogames
                .Include(vg => vg.Platform)
                .Include(vg => vg.Developer)
                .Include(vg => vg.Genre)
                .ToListAsync();

            var videogamesDto = mapper.Map<IEnumerable<VideogameDto>>(videogames);
            return videogamesDto;
        }

        public async Task<Videogame?> GetVideogameById(int id)
        {
            return await context.Videogames
                .Include(vg => vg.Platform)
                .Include(vg => vg.Developer)
                .Include(vg => vg.Genre)
                .FirstOrDefaultAsync(vg => vg.Id == id);
        }

        public VideogameDataDto GetVideogameDto(Videogame videogame)
        {
            return mapper.Map<VideogameDataDto>(videogame);
        }

        public async Task<bool> PutVideogame(Videogame videogame)
        {
            try
            {
                context.Update(videogame);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(ApiStrings.PutVideogameError + e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteVideogame(Videogame videogame)
        {
            try
            {
                context.Remove(videogame);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(ApiStrings.DeleteVideogameError + e.Message);
                return false;
            }
        }

        public async Task<bool> PatchVideogame(VideogamePatchDto videogamePatchDto, Videogame videogame)
        {
            try
            {
                mapper.Map(videogamePatchDto, videogame);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(ApiStrings.PatchVideogameError + e.Message);
                return false;
            }
        }
    }
}
