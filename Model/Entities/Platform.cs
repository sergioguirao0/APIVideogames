using APIVideogames.Resources.Strings;
using APIVideogames.Validations;
using System.ComponentModel.DataAnnotations;

namespace APIVideogames.Model.Entities
{
    public class Platform
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ApiStrings.RequiredField)]
        [StringLength(20, ErrorMessage = ApiStrings.StringLenght)]
        [FirstCharUpperCase]
        public required string Name { get; set; }

        [Range(1950, 2050, ErrorMessage = ApiStrings.RangeValidation)]
        public int ReleaseYear { get; set; }

        public List<Videogame> Videogames { get; set; } = [];
    }
}
