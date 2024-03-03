﻿using MoviesRating.Api.Entities;

namespace MoviesRating.Api.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllAsync();
        Task<Movie> GetAsync(Guid id);
        Task UpdateAsync (Movie movie);
        Task AddAsync (Movie movie);
        Task DeleteAsync(Movie movie);
        Task<Movie> GetMovieByTitleAndYearOfProductionAsync(string title, int yearOfProduction);
    }
}
