using System.ComponentModel.DataAnnotations;

namespace APIVideogames.Model.Entities
{
    public class Videogame
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public int ReleaseYear { get; set; }

        public int PlatformId { get; set; }
        public Platform? Platform { get; set; }
    }
}
