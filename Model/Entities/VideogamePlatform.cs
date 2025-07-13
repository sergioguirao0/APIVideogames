using Microsoft.EntityFrameworkCore;

namespace APIVideogames.Model.Entities
{
    [PrimaryKey(nameof(PlatformId), nameof(VideogameId))]
    public class VideogamePlatform
    {
        public int PlatformId { get; set; }
        public int VideogameId { get; set; }
        public int Order { get; set; }
        public Platform? Platform { get; set; }
        public Videogame? Videogame { get; set; }
    }
}
