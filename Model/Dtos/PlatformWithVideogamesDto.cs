using APIVideogames.Model.Entities;

namespace APIVideogames.Model.Dtos
{
    public class PlatformWithVideogamesDto : PlatformDto
    {
        public List<Videogame> Videogames { get; set; } = [];
    }
}
