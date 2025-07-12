using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;
using APIVideogames.Model.Repositories;
using APIVideogames.Resources.Strings;
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
            var videogame = videogameService.GetVideogameCreation(videogameCreationDto);
            bool platformExist = await videogameService.PlatformExist(videogame);

            if (!platformExist)
            {
                ModelState.AddModelError(nameof(videogame.PlatformId), ApiStrings.PlatformExistError);
                return ValidationProblem();
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
        public async Task<ActionResult<VideogameDto>> Get(int id)
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
            var videogame = videogameService.GetVideogameCreation(videogameCreationDto);
            bool platformExist = await videogameService.PlatformExist(videogame);

            if (!platformExist)
            {
                ModelState.AddModelError(nameof(videogame.PlatformId), ApiStrings.PlatformExistError);
                return ValidationProblem();
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

            videogame.Id = id;
            bool canPut = await videogameService.PutVideogame(videogame);

            if (!canPut)
            {
                return BadRequest();
            }

            return Ok();
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

            return Ok();
        }
    }
}
