using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;

namespace APIVideogames.Model.Repositories
{
    public interface IComentaryRepository
    {
        Task<bool> DeleteComentary(Comentary comentary);
        Task<Comentary?> GetComentaryById(Guid id);
        Comentary GetComentaryCreation(ComentaryCreationDto comentaryCreationDto);
        ComentaryDto GetComentaryDto(Comentary comentary);
        ComentaryPatchDto GetPatchComentary(Comentary comentary);
        Task<List<ComentaryDto>> GetVideogameComentaries(int videogameId);
        Task<bool> PatchComentary(ComentaryPatchDto comentaryPatchDto, Comentary comentary);
        Task<bool> PostComentary(Comentary comentary);
    }
}
