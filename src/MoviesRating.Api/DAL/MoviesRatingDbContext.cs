using Microsoft.EntityFrameworkCore;
using MoviesRating.Api.Entities;

namespace MoviesRating.Api.DAL
{
    public class MoviesRatingDbContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }

        public MoviesRatingDbContext(DbContextOptions<MoviesRatingDbContext> options) : base(options) 
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
