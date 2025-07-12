using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;

namespace APIVideogames.Model.Repositories
{
    public interface IPlatformRepository
    {
        Task<bool> PostPlatform(Platform platform);
        Task<IEnumerable<PlatformDto>> GetPlatforms();
        Task<Platform?> GetPlatformById(int id);
        Task<bool> PutPlatform(Platform platform);
        Task<bool> DeletePlatform(Platform platform);
        PlatformDto GetPlatformDto(Platform platform);
        Platform GetPlatformCreation(PlatformCreationDto platformPostDto);
    }
}
