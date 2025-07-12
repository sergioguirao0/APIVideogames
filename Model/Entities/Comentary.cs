using System.ComponentModel.DataAnnotations;

namespace APIVideogames.Model.Entities
{
    public class Comentary
    {
        public Guid Id { get; set; }

        [Required]
        public required string ComentaryBody { get; set; }

        public DateTime PublicationData { get; set; }

        public int VideogameId { get; set; }
        public Videogame? Videogame { get; set; }
    }
}
