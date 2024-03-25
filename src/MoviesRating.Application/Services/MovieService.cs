using MoviesRating.Application.Commands;
using MoviesRating.Application.DTO.Movies;
using MoviesRating.Application.Exceptions;
using MoviesRating.Domain.Entities;
using MoviesRating.Domain.Repositories;

namespace MoviesRating.Application.Services
{
    internal class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly IGenreRepository _genreRepository;

        public MovieService(IMovieRepository movieRepository, IDirectorRepository directorRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _directorRepository = directorRepository;
            _genreRepository = genreRepository;
        }

        public async Task<IEnumerable<MovieDto>> GetAllAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            return movies.Select(m => new MovieDto
            {
                MovieId = m.MovieId,
                Title = m.Title,
                Description = m.Description,
                YearOfProduction = m.YearOfProduction,
                Director = new MovieDirectorDto
                {
                    FirstName = m.Director.FirstName,
                    LastName = m.Director.LastName,
                },
                Genre = new MovieGenreDto
                {
                    GenreName = m.Genre.Name
                }
            });
        }

        public async Task<MovieDto> GetAsync(Guid id)
        {
            var movie = await _movieRepository.GetAsync(id);
            return new MovieDto
            {
                MovieId = movie.MovieId,
                Title = movie.Title,
                Description = movie.Description,
                YearOfProduction = movie.YearOfProduction,
                Director = new MovieDirectorDto
                {
                    FirstName = movie.Director.FirstName,
                    LastName = movie.Director.LastName,
                },
                Genre = new MovieGenreDto
                {
                    GenreName = movie.Genre.Name
                }
            };
        }

    }
}
