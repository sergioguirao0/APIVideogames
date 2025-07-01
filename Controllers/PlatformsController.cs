using APIVideogames.Model.Entities;
using APIVideogames.Model.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace APIVideogames.Controllers
{
    [ApiController]
    [Route("platforms")]
    public class PlatformsController(IPlatformRepository platformService) : ControllerBase
    {
        private readonly IPlatformRepository platformService = platformService;

        [HttpPost]
        public async Task<ActionResult> Post(Platform platform)
        {
            bool canPost = await platformService.PostPlatform(platform);

            if (!canPost)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IEnumerable<Platform>> Get()
        {
            return await platformService.GetPlatforms();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Platform>> Get(int id)
        {
            var platform = await platformService.GetPlatformById(id);

            if (platform is null)
            {
                return NotFound();
            }

            return platform;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Platform platform)
        {
            bool canPut = await platformService.PutPlatform(id, platform);

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
