using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;
using APIVideogames.Model.Repositories;
using APIVideogames.Resources.Strings;
using Microsoft.AspNetCore.Mvc;

namespace APIVideogames.Controllers
{
    [ApiController]
    [Route("genres")]
    public class GenresController(IGenreRepository genreService) : ControllerBase
    {
        private readonly IGenreRepository genreService = genreService;

        [HttpPost]
        public async Task<ActionResult<Genre>> Post(GenreCreationDto genreCreationDto)
        {
            var genre = genreService.GetGenreCreation(genreCreationDto);
            bool canPost = await genreService.PostGenre(genre);

            if (!canPost)
            {
                return BadRequest();
            }

            return CreatedAtRoute(ApiStrings.CreatedGenre, new { id = genre.Id }, genreCreationDto);
        }

        [HttpGet]
        public async Task<IEnumerable<GenreDto>> Get()
        {
            return await genreService.GetGenres();
        }

        [HttpGet("{id:int}", Name = ApiStrings.CreatedGenre)]
        public async Task<ActionResult<GenreDto>> Get(int id)
        {
            var genre = await genreService.GetGenreById(id);

            if (genre is null)
            {
                return NotFound();
            }

            var genreDto = genreService.GetGenreDto(genre);
            return genreDto;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, GenreCreationDto genreCreationDto)
        {
            var genre = genreService.GetGenreCreation(genreCreationDto);
            genre.Id = id;
            bool canPut = await genreService.PutGenre(genre);

            if (!canPut)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var genre = await genreService.GetGenreById(id);

            if (genre is null)
            {
                return NotFound();
            }

            bool canDelete = await genreService.DeleteGenre(genre);

            if (!canDelete)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
