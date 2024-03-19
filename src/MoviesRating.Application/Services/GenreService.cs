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

        public async Task<Guid> CreateAsync(CreateGenreDto createGenreDto)
        {
            var existingGenre = await _genreRepository.GetGenreByName(createGenreDto.Name);
            if (existingGenre != null)
            {
                throw new GenreExistException();
            }

            var genre = new Genre(Guid.NewGuid(), createGenreDto.Name);
            await _genreRepository.AddAsync(genre);
            return genre.GenreId;
        }

        public async Task DeleteAsync(DeleteGenreDto deleteGenreDto)
        {
            var deleteGenre = await _genreRepository.GetAsync(deleteGenreDto.GenreId);
            if (deleteGenre == null)
            {
                throw new GenreDoesNotExistException();
            }
            await _genreRepository.DeleteAsync(deleteGenre);
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

        public async Task UpdateAsync(UpdateGenreDto updateGenreDto)
        {
            var genre = await _genreRepository.GetAsync(updateGenreDto.GenreId);
            if (genre == null)
            {
               throw new GenreDoesNotExistException();
            }

            var existingGenre = await _genreRepository.GetGenreByName(updateGenreDto.Name);
            if (existingGenre != null)
            {
                throw new GenreDoesNotExistException();
            }
            genre.ChangeName(updateGenreDto.Name);

            await _genreRepository.UpdateAsync(genre);
        }
    }
}
