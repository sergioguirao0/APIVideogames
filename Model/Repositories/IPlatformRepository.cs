using APIVideogames.Model.Entities;

namespace APIVideogames.Model.Repositories
{
    public interface IPlatformRepository
    {
        Task<bool> PostPlatform(Platform platform);
        Task<IEnumerable<Platform>> GetPlatforms();
        Task<Platform?> GetPlatformById(int id);
        Task<bool> PutPlatform(int id, Platform platform);
        Task<bool> DeletePlatform(Platform platform);
    }
}
