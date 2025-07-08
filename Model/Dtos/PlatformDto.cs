using APIVideogames.Resources.Strings;
using APIVideogames.Validations;
using System.ComponentModel.DataAnnotations;

namespace APIVideogames.Model.Dtos
{
    public class PlatformDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ReleaseYear { get; set; }
    }
}
