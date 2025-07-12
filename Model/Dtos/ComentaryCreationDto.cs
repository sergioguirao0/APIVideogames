using System.ComponentModel.DataAnnotations;

namespace APIVideogames.Model.Dtos
{
    public class ComentaryCreationDto
    {
        [Required]
        public required string ComentaryBody { get; set; }
    }
}
