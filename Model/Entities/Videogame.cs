using APIVideogames.Resources.Strings;
using APIVideogames.Validations;
using System.ComponentModel.DataAnnotations;

namespace APIVideogames.Model.Entities
{
    public class Videogame
    {
        public int Id { get; set; }

        [Required(ErrorMessage = ApiStrings.RequiredField)]
        [StringLength(100, ErrorMessage = ApiStrings.StringLenght)]
        [FirstCharUpperCase]
        public required string Name { get; set; }

        [Range(1950, 2050, ErrorMessage = ApiStrings.RangeValidation)]
        public int ReleaseYear { get; set; }

        public List<VideogamePlatform> Platforms { get; set; } = [];

        public int DeveloperId { get; set; }
        public Developer? Developer { get; set; }

        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

        public List<Comentary> Comentaries { get; set; } = [];
    }
}
