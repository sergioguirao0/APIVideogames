namespace APIVideogames.Model.Dtos
{
    public class VideogameDataDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ReleaseYear { get; set; }
        public string? Platform { get; set; }
        public string? Developer { get; set; }
        public string? Genre { get; set; }
    }
}
