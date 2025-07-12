using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;

namespace APIVideogames.Model.Repositories
{
    public interface IDeveloperRepository
    {
        Task<bool> DeleteDeveloper(Developer developer);
        Task<Developer?> GetDeveloperById(int id);
        Developer GetDeveloperCreation(DeveloperCreationDto developerCreationDto);
        DeveloperDto GetDeveloperDto(Developer developer);
        Task<IEnumerable<DeveloperDto>> GetDevelopers();
        Task<bool> PostDeveloper(Developer developer);
        Task<bool> PutDeveloper(Developer developer);
    }
}
