using APIVideogames.Data;
using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;
using APIVideogames.Model.Repositories;
using APIVideogames.Resources.Strings;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIVideogames.Services
{
    public class PlatformService(ApplicationDbContext context, ILogger<PlatformService> logger, IMapper mapper) : IPlatformRepository
    {
        private readonly ApplicationDbContext context = context;
        private readonly ILogger<PlatformService> logger = logger;
        private readonly IMapper mapper = mapper;

        public async Task<bool> PostPlatform(Platform platform)
        {
            try
            {
                context.Add(platform);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(ApiStrings.PostPlatformError + e.Message);
                return false;
            }
        }

        public async Task<IEnumerable<PlatformDto>> GetPlatforms()
        {
            var platforms = await context.Platforms.ToListAsync();
            var platformsList = mapper.Map<IEnumerable<PlatformDto>>(platforms);
            return platformsList;
        }

        public async Task<Platform?> GetPlatformById(int id)
        {
            return await context.Platforms
                .Include(platform => platform.Videogames)
                .FirstOrDefaultAsync(platform => platform.Id == id);
        }

        public PlatformDto GetPlatformDto(Platform platform)
        {
            return mapper.Map<PlatformDto>(platform);
        }

        public Platform GetPlatformCreation(PlatformCreationDto platformPostDto)
        {
            return mapper.Map<Platform>(platformPostDto);
        }

        public async Task<bool> PutPlatform(int id, Platform platform)
        {
            try
            {
                context.Update(platform);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(ApiStrings.PutPlatformError + e.Message);
                return false;
            }
        }

        public async Task<bool> DeletePlatform(Platform platform)
        {
            try
            {
                context.Remove(platform);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(ApiStrings.DeletePlatformError + e.Message);
                return false;
            }
        }
    }
}
