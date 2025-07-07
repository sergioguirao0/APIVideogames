using APIVideogames.Resources.Strings;
using APIVideogames.Validations;
using System.ComponentModel.DataAnnotations;

namespace APIVideogames.Model.Entities
{
    public class Videogame
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ApiStrings.RequiredField)]
        [StringLength(50, ErrorMessage = ApiStrings.StringLenght)]
        [FirstCharUpperCase]
        public required string Name { get; set; }

        [Range(1950, 2050, ErrorMessage = ApiStrings.RangeValidation)]
        public int ReleaseYear { get; set; }

        public int PlatformId { get; set; }
        public Platform? Platform { get; set; }
    }
}
