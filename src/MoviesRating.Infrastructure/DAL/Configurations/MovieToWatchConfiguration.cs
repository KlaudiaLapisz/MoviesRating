using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesRating.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Infrastructure.DAL.Configurations
{
    internal class MovieToWatchConfiguration : IEntityTypeConfiguration<MovieToWatch>
    {
        public void Configure(EntityTypeBuilder<MovieToWatch> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MovieId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

            builder.HasOne(x=>x.User).WithMany(x=>x.MoviesToWatch).HasForeignKey(x=>x.UserId);
            


            builder.ToTable(nameof(MovieToWatch));
        }
    }
}
