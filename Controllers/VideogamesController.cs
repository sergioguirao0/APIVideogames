using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;
using APIVideogames.Model.Repositories;
using APIVideogames.Resources.Strings;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace APIVideogames.Controllers
{
    [ApiController]
    [Route("videogames")]
    public class VideogamesController(IVideogameRepository videogameService) : ControllerBase
    {
        private readonly IVideogameRepository videogameService = videogameService;

        [HttpPost]
        public async Task<ActionResult> Post(VideogameCreationDto videogameCreationDto)
        {
            if (videogameCreationDto.PlatformsId is null || videogameCreationDto.PlatformsId.Count == 0)
            {
                ModelState.AddModelError(nameof(videogameCreationDto.PlatformsId), ApiStrings.NoPlatformsInVideogameError);
                return ValidationProblem();
            }

            var platformsIdExist = await videogameService.PlatformExist(videogameCreationDto);

            if (platformsIdExist.Count != videogameCreationDto.PlatformsId.Count)
            {
                var inexistentPlatforms = videogameCreationDto.PlatformsId.Except(platformsIdExist);
                var inexistentPlatformsString = string.Join(",", inexistentPlatforms);
                var errorMessage = ApiStrings.InexistentPlatformsError + inexistentPlatformsString;
                ModelState.AddModelError(nameof(videogameCreationDto.PlatformsId), errorMessage);
                return ValidationProblem();
            }

            var videogame = videogameService.GetVideogameCreation(videogameCreationDto);

            bool developerExist = await videogameService.DeveloperExist(videogame);

            if (!developerExist)
            {
                ModelState.AddModelError(nameof(videogame.DeveloperId), ApiStrings.DeveloperExistError);
                return ValidationProblem();
            }

            bool genreExist = await videogameService.GenreExist(videogame);

            if (!genreExist)
            {
                ModelState.AddModelError(nameof(videogame.GenreId), ApiStrings.GenreExistError);
                return ValidationProblem();
            }

            videogameService.VideogamePlatformOrder(videogame);

            bool canPost = await videogameService.PostVideogame(videogame);

            if (!canPost)
            {
                return BadRequest();
            }

            return CreatedAtRoute(ApiStrings.CreatedVideogame, new { id = videogame.Id }, videogameCreationDto);
        }

        [HttpGet]
        public async Task<IEnumerable<VideogameDto>> Get()
        {
            return await videogameService.GetVideogames();
        }

        [HttpGet("{id:int}", Name = ApiStrings.CreatedVideogame)]
        public async Task<ActionResult<VideogameDataDto>> Get(int id)
        {
            var videogame = await videogameService.GetVideogameById(id);

            if (videogame is null)
            {
                return NotFound();
            }

            var videogameDto = videogameService.GetVideogameDto(videogame);
            return videogameDto;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, VideogameCreationDto videogameCreationDto)
        {
            if (videogameCreationDto.PlatformsId is null || videogameCreationDto.PlatformsId.Count == 0)
            {
                ModelState.AddModelError(nameof(videogameCreationDto.PlatformsId), ApiStrings.NoPlatformsInVideogameError);
                return ValidationProblem();
            }

            var platformsIdExist = await videogameService.PlatformExist(videogameCreationDto);

            if (platformsIdExist.Count != videogameCreationDto.PlatformsId.Count)
            {
                var inexistentPlatforms = videogameCreationDto.PlatformsId.Except(platformsIdExist);
                var inexistentPlatformsString = string.Join(",", inexistentPlatforms);
                var errorMessage = ApiStrings.InexistentPlatformsError + inexistentPlatformsString;
                ModelState.AddModelError(nameof(videogameCreationDto.PlatformsId), errorMessage);
                return ValidationProblem();
            }

            var videogame = await videogameService.GetVideogameById(id);

            if (videogame is null)
            {
                return NotFound();
            }

            bool developerExist = await videogameService.DeveloperExist(videogame);

            if (!developerExist)
            {
                ModelState.AddModelError(nameof(videogame.DeveloperId), ApiStrings.DeveloperExistError);
                return ValidationProblem();
            }

            bool genreExist = await videogameService.GenreExist(videogame);

            if (!genreExist)
            {
                ModelState.AddModelError(nameof(videogame.GenreId), ApiStrings.GenreExistError);
                return ValidationProblem();
            }

            videogame = videogameService.GetVideogameCreation(videogameCreationDto);
            videogameService.VideogamePlatformOrder(videogame);
            bool canPut = await videogameService.PutVideogame();

            if (!canPut)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult> Patch(int id, JsonPatchDocument<VideogamePatchDto> patchDoc)
        {
            if (patchDoc is null)
            {
                return BadRequest();
            }

            var videogameDb = await videogameService.GetVideogameById(id);

            if (videogameDb is null)
            {
                return NotFound();
            }

            var videogamePatchDto = videogameService.GetPatchVideogame(videogameDb);
            patchDoc.ApplyTo(videogamePatchDto, ModelState);
            bool validPatch = TryValidateModel(videogamePatchDto);

            if (!validPatch)
            {
                return ValidationProblem();
            }

            bool canPatch = await videogameService.PatchVideogame(videogamePatchDto, videogameDb);

            if (!canPatch)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var videogame = await videogameService.GetVideogameById(id);

            if (videogame is null)
            {
                return NotFound();
            }

            bool canDelete = await videogameService.DeleteVideogame(videogame);

            if (!canDelete)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
