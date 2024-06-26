﻿using Microsoft.EntityFrameworkCore;
using MoviesRating.Domain.Entities;

namespace MoviesRating.Infrastructure.DAL
{
    internal class MoviesRatingDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<FavouriteMovie> Favourites { get; set; }
        public DbSet<MovieToWatch> MoviesToWatch { get; set; }

        public MoviesRatingDbContext(DbContextOptions<MoviesRatingDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
