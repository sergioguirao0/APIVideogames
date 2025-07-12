using APIVideogames.Resources.Strings;
using APIVideogames.Validations;
using System.ComponentModel.DataAnnotations;

namespace APIVideogames.Model.Dtos
{
    public class GenreDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
