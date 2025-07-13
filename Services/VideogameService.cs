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

        public VideogamePatchDto GetPatchVideogame(Videogame videogame)
        {
            return mapper.Map<VideogamePatchDto>(videogame);
        }

        public async Task<List<int>> PlatformExist(VideogameCreationDto videogameCreationDto)
        {
            return await context.Platforms.Where(pt => videogameCreationDto.PlatformsId.Contains(pt.Id))
                .Select(pt => pt.Id).ToListAsync();
        }

        public async Task<List<Platform>> GetPlatformsByIds(List<int> platformIds)
        {
            return await context.Platforms
                .Where(p => platformIds.Contains(p.Id))
                .ToListAsync();
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
                .Include(vg => vg.Platforms)
                .Include(vg => vg.Developer)
                .Include(vg => vg.Genre)
                .ToListAsync();

            var videogamesDto = mapper.Map<IEnumerable<VideogameDto>>(videogames);
            return videogamesDto;
        }

        public async Task<Videogame?> GetVideogameById(int id)
        {
            return await context.Videogames
                .Include(vg => vg.Platforms)
                .Include(vg => vg.Developer)
                .Include(vg => vg.Genre)
                .FirstOrDefaultAsync(vg => vg.Id == id);
        }

        public VideogameDataDto GetVideogameDto(Videogame videogame)
        {
            return mapper.Map<VideogameDataDto>(videogame);
        }

        public async Task<bool> PutVideogame()
        {
            try
            {
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

        public void VideogamePlatformOrder(Videogame videogame)
        {
            if (videogame.Platforms is not null)
            {
                for (int i = 0; i < videogame.Platforms.Count; i++)
                {
                    videogame.Platforms[i].Order = i;
                }
            }
        }
    }
}
