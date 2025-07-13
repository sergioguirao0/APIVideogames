using APIVideogames.Model.Entities;
using APIVideogames.Resources.Strings;
using APIVideogames.Validations;
using System.ComponentModel.DataAnnotations;

namespace APIVideogames.Model.Dtos
{
    public class VideogameCreationDto
    {
        [Required(ErrorMessage = ApiStrings.RequiredField)]
        [StringLength(100, ErrorMessage = ApiStrings.StringLenght)]
        [FirstCharUpperCase]
        public required string Name { get; set; }

        [Range(1950, 2050, ErrorMessage = ApiStrings.RangeValidation)]
        public int ReleaseYear { get; set; }

        public List<int> PlatformsId { get; set; } = [];
        public int DeveloperId { get; set; }
        public int GenreId { get; set; }
    }
}
