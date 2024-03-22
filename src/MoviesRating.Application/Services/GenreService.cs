using MoviesRating.Application.Commands;
using MoviesRating.Application.DTO.Genres;
using MoviesRating.Application.Exceptions;
using MoviesRating.Domain.Entities;
using MoviesRating.Domain.Repositories;

namespace MoviesRating.Application.Services
{
    internal class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
               
        public async Task<IEnumerable<GenreDto>> GetAllAsync()
        {
            var genres = await _genreRepository.GetAllAsync();
            return genres.Select(g => new GenreDto
            {
                GenreId = g.GenreId,
                Name = g.Name
            });
        }

        public async Task<GenreDto> GetAsync(Guid id)
        {
            var genre = await _genreRepository.GetAsync(id);
            return new GenreDto
            {
                GenreId = genre.GenreId,
                Name = genre.Name
            };
        }

    }
}
