using APIVideogames.Data;
using APIVideogames.Model.Entities;
using APIVideogames.Model.Repositories;
using APIVideogames.Resources.Strings;
using Microsoft.EntityFrameworkCore;

namespace APIVideogames.Services
{
    public class PlatformService(ApplicationDbContext context, ILogger<PlatformService> logger) : IPlatformRepository
    {
        private readonly ApplicationDbContext context = context;
        private readonly ILogger<PlatformService> logger = logger;

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

        public async Task<IEnumerable<Platform>> GetPlatforms()
        {
            return await context.Platforms
                .Include(platform => platform.Videogames)
                .ToListAsync();
        }

        public async Task<Platform?> GetPlatformById(int id)
        {
            return await context.Platforms
                .Include(platform => platform.Videogames)
                .FirstOrDefaultAsync(platform => platform.Id == id);
        }

        public async Task<bool> PutPlatform(int id, Platform platform)
        {
            try
            {
                if (id != platform.Id)
                {
                    return false;
                }

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
