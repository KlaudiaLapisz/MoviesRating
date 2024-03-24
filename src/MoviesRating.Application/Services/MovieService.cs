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

        public async Task DeleteAsync(DeleteMovieDto deleteMovieDto)
        {
            var deleteMovie = await _movieRepository.GetAsync(deleteMovieDto.MovieId);
            if (deleteMovie == null)
            {
                throw new MovieDoesNotExistException();
            }

            await _movieRepository.DeleteAsync(deleteMovie);
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

        public async Task UpdateAsync(UpdateMovieDto updateMovieDto)
        {
            var movie = await _movieRepository.GetAsync(updateMovieDto.MovieId);
            if (movie == null)
            {
                throw new MovieDoesNotExistException();
            }

            var existingMovie = await _movieRepository.GetMovieByTitleAndYearOfProductionAsync(updateMovieDto.Title, updateMovieDto.YearOfProduction);
            if (existingMovie != null)
            {
                throw new MovieExistException();
            }

            var director = await _directorRepository.GetAsync(updateMovieDto.DirectorId);
            if (director == null)
            {
                throw new DirectorDoesNotExistException();
            }

            var genre = await _genreRepository.GetAsync(updateMovieDto.GenreId);
            if (genre == null)
            {
                throw new GenreDoesNotExistException();
            }

            movie.ChangeTitle(updateMovieDto.Title);
            movie.ChangeDescription(updateMovieDto.Description);
            movie.ChangeYearOfProduction(updateMovieDto.YearOfProduction);
            movie.ChangeDirector(director);
            movie.ChangeGenre(genre);

            await _movieRepository.UpdateAsync(movie);
        }
    }
}
