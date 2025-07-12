using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;
using APIVideogames.Model.Repositories;
using APIVideogames.Resources.Strings;
using Microsoft.AspNetCore.Mvc;

namespace APIVideogames.Controllers
{
    [ApiController]
    [Route("platforms")]
    public class PlatformsController(IPlatformRepository platformService) : ControllerBase
    {
        private readonly IPlatformRepository platformService = platformService;

        [HttpPost]
        public async Task<ActionResult> Post(PlatformCreationDto platformPostDto)
        {
            var platform = platformService.GetPlatformCreation(platformPostDto);
            bool canPost = await platformService.PostPlatform(platform);

            if (!canPost)
            {
                return BadRequest();
            }

            var platformDto = platformService.GetPlatformDto(platform);

            return CreatedAtRoute(ApiStrings.CreatedPlatform, new { id = platform.Id }, platformDto);
        }

        [HttpGet]
        public async Task<IEnumerable<PlatformDto>> Get()
        {
            return await platformService.GetPlatforms();
        }

        [HttpGet("{id:int}", Name = ApiStrings.CreatedPlatform)]
        public async Task<ActionResult<PlatformDto>> Get(int id)
        {
            var platform = await platformService.GetPlatformById(id);

            if (platform is null)
            {
                return NotFound();
            }

            var platformDto = platformService.GetPlatformDto(platform);
            
            return platformDto;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, PlatformCreationDto platformPutDto)
        {
            var platform = platformService.GetPlatformCreation(platformPutDto);
            platform.Id = id;
            bool canPut = await platformService.PutPlatform(platform);

            if (!canPut)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var platform = await platformService.GetPlatformById(id);

            if (platform is null)
            {
                return NotFound();
            }

            bool canDelete = await platformService.DeletePlatform(platform);

            if (!canDelete)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
