using System.ComponentModel.DataAnnotations;

namespace APIVideogames.Model.Entities
{
    public class Platform
    {
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }
    }
}
