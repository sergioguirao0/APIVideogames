using APIVideogames.Model.Entities;
using APIVideogames.Resources.Strings;
using APIVideogames.Validations;
using System.ComponentModel.DataAnnotations;

namespace APIVideogames.Model.Dtos
{
    public class VideogameDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ReleaseYear { get; set; }
        public int PlatformId { get; set; }
        public int DeveloperId { get; set; }
        public int GenreId { get; set; }
    }
}
