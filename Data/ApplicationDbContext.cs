using APIVideogames.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace APIVideogames.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Videogame> Videogames { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Comentary> Comentaries { get; set; }   
    }
}
