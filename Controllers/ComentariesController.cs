using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;
using APIVideogames.Model.Repositories;
using APIVideogames.Resources.Strings;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace APIVideogames.Controllers
{
    [ApiController]
    [Route("videogames/{videogameId:int}/comentaries")]
    public class ComentariesController(IComentaryRepository comentaryService, IVideogameRepository videogameService) : ControllerBase
    {
        private readonly IComentaryRepository comentaryService = comentaryService;
        private readonly IVideogameRepository videogameService = videogameService;

        [HttpGet]
        public async Task<ActionResult<List<ComentaryDto>>> Get(int videogameId)
        {
            var videogame = await videogameService.GetVideogameById(videogameId);

            if (videogame is null)
            {
                return NotFound();
            }

            return await comentaryService.GetVideogameComentaries(videogameId);
        }

        [HttpGet("{id}", Name = ApiStrings.GetComentary)]
        public async Task<ActionResult<ComentaryDto>> Get(Guid id)
        {
            var comentary = await comentaryService.GetComentaryById(id);

            if (comentary is null)
            {
                return NotFound();
            }

            return comentaryService.GetComentaryDto(comentary);
        }

        [HttpPost]
        public async Task<ActionResult> Post(int videogameId, ComentaryCreationDto comentaryCreationDto)
        {
            var videogame = await videogameService.GetVideogameById(videogameId);

            if (videogame is null)
            {
                return NotFound();
            }

            var comentary = comentaryService.GetComentaryCreation(comentaryCreationDto);
            comentary.VideogameId = videogameId;
            comentary.PublicationData = DateTime.UtcNow;

            bool canPost = await comentaryService.PostComentary(comentary);

            if (!canPost)
            {
                return BadRequest();
            }

            var comentaryDto = comentaryService.GetComentaryDto(comentary);
            return CreatedAtRoute(ApiStrings.GetComentary, new { id = comentary.Id, videogameId }, comentaryDto);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Patch(Guid id, int videogameId, JsonPatchDocument<ComentaryPatchDto> patchDoc)
        {
            if (patchDoc is null)
            {
                return BadRequest();
            }

            var videogame = await videogameService.GetVideogameById(videogameId);

            if (videogame is null)
            {
                return NotFound();
            }

            var comentaryDb = await comentaryService.GetComentaryById(id);

            if (comentaryDb is null)
            {
                return NotFound();
            }

            var comentaryPatchDto = comentaryService.GetPatchComentary(comentaryDb);
            patchDoc.ApplyTo(comentaryPatchDto, ModelState);
            bool validPatch = TryValidateModel(comentaryPatchDto);

            if (!validPatch)
            {
                return ValidationProblem();
            }

            bool canPatch = await comentaryService.PatchComentary(comentaryPatchDto, comentaryDb);

            if (!canPatch)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id, int videogameId)
        {
            var videogame = await videogameService.GetVideogameById(videogameId);

            if (videogame is null)
            {
                return NotFound();
            }

            var comentary = await comentaryService.GetComentaryById(id);

            if (comentary is null)
            {
                return NotFound();
            }

            bool canDelete = await comentaryService.DeleteComentary(comentary);

            if (!canDelete)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
