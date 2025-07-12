using APIVideogames.Data;
using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;
using APIVideogames.Model.Repositories;
using APIVideogames.Resources.Strings;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIVideogames.Services
{
    public class DeveloperService(ApplicationDbContext context, ILogger<DeveloperService> logger, IMapper mapper) : IDeveloperRepository
    {
        private readonly ApplicationDbContext context = context;
        private readonly ILogger<DeveloperService> logger = logger;
        private readonly IMapper mapper = mapper;

        public async Task<bool> PostDeveloper(Developer developer)
        {
            try
            {
                context.Add(developer);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(ApiStrings.PostDeveloperError + e.Message);
                return false;
            }
        }

        public Developer GetDeveloperCreation(DeveloperCreationDto developerCreationDto)
        {
            return mapper.Map<Developer>(developerCreationDto);
        }

        public async Task<IEnumerable<DeveloperDto>> GetDevelopers()
        {
            var developers = await context.Developers.ToListAsync();
            var developersDto = mapper.Map<IEnumerable<DeveloperDto>>(developers);
            return developersDto;
        }

        public async Task<Developer?> GetDeveloperById(int id)
        {
            return await context.Developers
                .Include(dev => dev.Videogames)
                .FirstOrDefaultAsync(dev => dev.Id == id);
        }

        public DeveloperDto GetDeveloperDto(Developer developer)
        {
            return mapper.Map<DeveloperDto>(developer);
        }

        public async Task<bool> PutDeveloper(Developer developer)
        {
            try
            {
                context.Update(developer);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(ApiStrings.PutDeveloperError + e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteDeveloper(Developer developer)
        {
            try
            {
                context.Remove(developer);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(ApiStrings.DeleteDeveloperError + e.Message);
                return false;
            }
        }
    }
}
