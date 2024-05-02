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
    internal class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Value).IsRequired();
            builder.Property(x=>x.UserId).IsRequired();
            builder.Property(x=>x.MovieId).IsRequired();

            builder.HasOne(x=>x.Movie).WithMany(x=>x.Rates).HasForeignKey(x=>x.MovieId);
            builder.HasOne(x => x.User).WithMany(x => x.Rates).HasForeignKey(x => x.UserId);

            builder.ToTable(nameof(Rate));
        }
    }
}
