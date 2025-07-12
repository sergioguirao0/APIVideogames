using APIVideogames.Resources.Strings;
using APIVideogames.Validations;
using System.ComponentModel.DataAnnotations;

namespace APIVideogames.Model.Entities
{
    public class Developer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = ApiStrings.StringLenght)]
        [FirstCharUpperCase]
        public required string Name { get; set; }

        [Range(1950, 2050, ErrorMessage = ApiStrings.RangeValidation)]
        public int FoundationYear { get; set; }

        public List<Videogame> Videogames { get; set; } = [];
    }
}
