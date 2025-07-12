using APIVideogames.Resources.Strings;
using APIVideogames.Validations;
using System.ComponentModel.DataAnnotations;

namespace APIVideogames.Model.Dtos
{
    public class DeveloperDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int FoundationYear { get; set; }
    }
}
