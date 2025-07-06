using System.ComponentModel.DataAnnotations;

namespace APIVideogames.Model.Entities
{
    public class Platform
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        public int ReleaseYear { get; set; }

        public List<Videogame> Videogames { get; set; } = [];
    }
}
