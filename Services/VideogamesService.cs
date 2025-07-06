using APIVideogames.Data;
using APIVideogames.Model.Entities;
using APIVideogames.Model.Repositories;
using Microsoft.EntityFrameworkCore;

namespace APIVideogames.Services
{
    public class VideogamesService(ApplicationDbContext context) : IVideogameRepository
    {
        private readonly ApplicationDbContext context = context;

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
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
        }

        public async Task<bool> PlatformExist(Videogame videogame)
        {
            return await context.Platforms.AnyAsync(pf => pf.Id == videogame.PlatformId);
        }

        public async Task<IEnumerable<Videogame>> GetVideogames()
        {
            return await context.Videogames.ToListAsync();
        }

        public async Task<Videogame?> GetVideogameById(int id)
        {
            return await context.Videogames
                .Include(vg => vg.Platform)
                .FirstOrDefaultAsync(vg => vg.Id == id);
        }

        public async Task<bool> PutVideogame(int id, Videogame videogame)
        {
            try
            {
                if (id != videogame.Id)
                {
                    return false;
                }

                context.Update(videogame);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
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
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
        }
    }
}
