using APIVideogames.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIVideogames.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Platform> Platforms { get; set; }
    }
}
