using MoviesRating.Application.DTO.Movies;
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

        public async Task<Guid?> CreateAsync(CreateMovieDto createMovieDto)
        {
            var existingMovie = await _movieRepository.GetMovieByTitleAndYearOfProductionAsync(createMovieDto.Title, createMovieDto.YearOfProduction);
            if (existingMovie != null)
            {
                return null;
            }

            var director = await _directorRepository.GetAsync(createMovieDto.DirectorId);
            if (director == null)
            {
                return null;
            }

            var genre = await _genreRepository.GetAsync(createMovieDto.GenreId);
            if (genre == null)
            {
                return null;
            }

            var movie = new Movie(Guid.NewGuid(), createMovieDto.Title, createMovieDto.YearOfProduction, createMovieDto.Description, director, genre);
            await _movieRepository.AddAsync(movie);
            return movie.MovieId;
        }

        public async Task<bool> DeleteAsync(DeleteMovieDto deleteMovieDto)
        {
            var deleteMovie = await _movieRepository.GetAsync(deleteMovieDto.MovieId);
            if (deleteMovie == null)
            {
                return false;
            }

            await _movieRepository.DeleteAsync(deleteMovie);
            return true;
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

        public async Task<bool> UpdateAsync(UpdateMovieDto updateMovieDto)
        {
            var movie = await _movieRepository.GetAsync(updateMovieDto.MovieId);
            if (movie == null)
            {
                return false;
            }

            var existingMovie = await _movieRepository.GetMovieByTitleAndYearOfProductionAsync(updateMovieDto.Title, updateMovieDto.YearOfProduction);
            if (existingMovie != null)
            {
                return false;
            }

            var director = await _directorRepository.GetAsync(updateMovieDto.DirectorId);
            if (director == null)
            {
                return false;
            }

            var genre = await _genreRepository.GetAsync(updateMovieDto.GenreId);
            if (genre == null)
            {
                return false;
            }

            movie.ChangeTitle(updateMovieDto.Title);
            movie.ChangeDescription(updateMovieDto.Description);
            movie.ChangeYearOfProduction(updateMovieDto.YearOfProduction);
            movie.ChangeDirector(director);
            movie.ChangeGenre(genre);

            await _movieRepository.UpdateAsync(movie);
            return true;
        }
    }
}
