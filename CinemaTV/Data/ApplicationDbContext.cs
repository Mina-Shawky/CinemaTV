using CinemaTV.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaTV.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>()
              .HasData(
                        new Genre { Id = 1, Name = "Action" },
                        new Genre { Id = 2, Name = "Drama" },
                        new Genre { Id = 3, Name = "Documentary" },
                        new Genre { Id = 4, Name = "Crime" },
                        new Genre { Id = 5, Name = "Comedy" },
                        new Genre { Id = 6, Name = "Animation" },
                        new Genre { Id = 7, Name = "Adventure" },
                        new Genre { Id = 8, Name = "History" },
                        new Genre { Id = 9, Name = "Western" },
                        new Genre { Id = 10, Name = "War" },
                        new Genre { Id = 11, Name = "Thriller" },
                        new Genre { Id = 12, Name = "Sci-Fi" },
                        new Genre { Id = 13, Name = "Romance" },
                        new Genre { Id = 14, Name = "Mystery" },
                        new Genre { Id = 15, Name = "Horror" },
                        new Genre { Id = 16, Name = "Sport" },
                        new Genre { Id = 17, Name = "Biography" },
                        new Genre { Id = 18, Name = "Family" });

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }

    }
}
