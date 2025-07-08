using APIVideogames.Resources.Strings;
using APIVideogames.Validations;
using System.ComponentModel.DataAnnotations;

namespace APIVideogames.Model.Dtos
{
    public class PlatformCreationDto
    {
        [Required(ErrorMessage = ApiStrings.RequiredField)]
        [StringLength(50, ErrorMessage = ApiStrings.StringLenght)]
        [FirstCharUpperCase]
        public required string Name { get; set; }

        [Range(1950, 2050, ErrorMessage = ApiStrings.RangeValidation)]
        public int ReleaseYear { get; set; }
    }
}
