using System.ComponentModel.DataAnnotations;

namespace APIVideogames.Model.Dtos
{
    public class ComentaryDto
    {
        public Guid Id { get; set; }
        public required string ComentaryBody { get; set; }
        public DateTime PublicationData { get; set; }
    }
}
