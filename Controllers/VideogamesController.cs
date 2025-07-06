using APIVideogames.Model.Entities;
using APIVideogames.Model.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIVideogames.Controllers
{
    [ApiController]
    [Route("videogames")]
    public class VideogamesController(IVideogameRepository videogameService) : ControllerBase
    {
        private readonly IVideogameRepository videogameService = videogameService;

        [HttpPost]
        public async Task<ActionResult> Post(Videogame videogame)
        {
            bool platformExist = await videogameService.PlatformExist(videogame);

            if (!platformExist)
            {
                return BadRequest($"La plataforma de {videogame.PlatformId} no existe");
            }

            bool canPost = await videogameService.PostVideogame(videogame);

            if (!canPost)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<Videogame>> Get()
        {
            return await videogameService.GetVideogames();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Videogame>> Get(int id)
        {
            var videogame = await videogameService.GetVideogameById(id);

            if (videogame is null)
            {
                return NotFound();
            }

            return videogame;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Videogame videogame)
        {
            bool platformExist = await videogameService.PlatformExist(videogame);

            if (!platformExist)
            {
                return BadRequest($"La plataforma de {videogame.PlatformId} no existe");
            }

            bool canPut = await videogameService.PutVideogame(id, videogame);

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
