using APIVideogames.Data;
using APIVideogames.Model.Entities;
using APIVideogames.Model.Repositories;
using Microsoft.EntityFrameworkCore;

namespace APIVideogames.Services
{
    public class PlatformService(ApplicationDbContext context) : IPlatformRepository
    {
        private readonly ApplicationDbContext context = context;

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
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Platform>> GetPlatforms()
        {
            return await context.Platforms.ToListAsync();
        }

        public async Task<Platform?> GetPlatformById(int id)
        {
            return await context.Platforms.FirstOrDefaultAsync(platform => platform.Id == id);
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
                Console.WriteLine("Error: " + e.Message);
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
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
        }
    }
}
