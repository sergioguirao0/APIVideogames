using APIVideogames.Model.Dtos;
using APIVideogames.Model.Entities;
using APIVideogames.Model.Repositories;
using APIVideogames.Resources.Strings;
using Microsoft.AspNetCore.Mvc;

namespace APIVideogames.Controllers
{
    [ApiController]
    [Route("developers")]
    public class DevelopersController(IDeveloperRepository developerService) : ControllerBase
    {
        private readonly IDeveloperRepository developerService = developerService;

        [HttpPost]
        public async Task<ActionResult> Post(DeveloperCreationDto developerCreationDto)
        {
            var developer = developerService.GetDeveloperCreation(developerCreationDto);
            bool canPost = await developerService.PostDeveloper(developer);

            if (!canPost)
            {
                return BadRequest();
            }

            return CreatedAtRoute(ApiStrings.CreatedDeveloper, new { id = developer.Id }, developerCreationDto);
        }

        [HttpGet]
        public async Task<IEnumerable<DeveloperDto>> Get()
        {
            return await developerService.GetDevelopers();
        }

        [HttpGet("{id:int}", Name = ApiStrings.CreatedDeveloper)]
        public async Task<ActionResult<DeveloperDto>> Get(int id)
        {
            var developer = await developerService.GetDeveloperById(id);

            if (developer is null)
            {
                return NotFound();
            }

            var developerDto = developerService.GetDeveloperDto(developer);
            return developerDto;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, DeveloperCreationDto developerCreationDto)
        {
            var developer = developerService.GetDeveloperCreation(developerCreationDto);
            developer.Id = id;
            bool canPut = await developerService.PutDeveloper(developer);

            if (!canPut)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var developer = await developerService.GetDeveloperById(id);

            if (developer is null)
            {
                return NotFound();
            }

            bool canDelete = await developerService.DeleteDeveloper(developer);

            if (!canDelete)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
