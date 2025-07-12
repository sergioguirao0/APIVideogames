using APIVideogames.Data;
using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;
using APIVideogames.Model.Repositories;
using APIVideogames.Resources.Strings;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIVideogames.Services
{
    public class ComentaryService(ApplicationDbContext context, ILogger<ComentaryService> logger, IMapper mapper) : IComentaryRepository
    {
        private readonly ApplicationDbContext context = context;
        private readonly ILogger<ComentaryService> logger = logger;
        private readonly IMapper mapper = mapper;

        public async Task<List<ComentaryDto>> GetVideogameComentaries(int videogameId)
        {
            var comentaries = await context.Comentaries
                .Where(com => com.VideogameId == videogameId)
                .OrderByDescending(com => com.PublicationData)
                .ToListAsync();

            return mapper.Map<List<ComentaryDto>>(comentaries);
        }

        public async Task<Comentary?> GetComentaryById(Guid id)
        {
            return await context.Comentaries.FirstOrDefaultAsync(c => c.Id == id);
        }

        public ComentaryDto GetComentaryDto(Comentary comentary)
        {
            return mapper.Map<ComentaryDto>(comentary);
        }

        public Comentary GetComentaryCreation(ComentaryCreationDto comentaryCreationDto)
        {
            return mapper.Map<Comentary>(comentaryCreationDto);
        }

        public async Task<bool> PostComentary(Comentary comentary)
        {
            try
            {
                context.Add(comentary);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(ApiStrings.PostComentaryError + e.Message);
                return false;
            }
        }

        public async Task<bool> PatchComentary(ComentaryPatchDto comentaryPatchDto, Comentary comentary)
        {
            try
            {
                mapper.Map(comentaryPatchDto, comentary);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(ApiStrings.PatchComentaryError + e.Message);
                return false;
            }
        }

        public ComentaryPatchDto GetPatchComentary(Comentary comentary)
        {
            return mapper.Map<ComentaryPatchDto>(comentary);
        }

        public async Task<bool> DeleteComentary(Comentary comentary)
        {
            try
            {
                context.Remove(comentary);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                logger.LogError(ApiStrings.DeleteComentaryError + e.Message);
                return false;
            }
        }
    }
}
