using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesRating.Domain.Entities;

namespace MoviesRating.Infrastructure.DAL.Configurations
{
    internal class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.MovieId);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.YearOfProduction).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);

            builder.HasOne(x => x.Director).WithMany(x => x.Movies).HasForeignKey(x => x.DirectorId);
            builder.HasOne(x => x.Genre).WithMany(x => x.Movies).HasForeignKey(x => x.GenreId);

            builder.ToTable(nameof(Movie));
        }
    }
}
