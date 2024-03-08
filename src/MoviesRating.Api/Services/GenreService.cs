using MoviesRating.Api.DTO.Genres;
using MoviesRating.Api.Entities;
using MoviesRating.Api.Repositories;

namespace MoviesRating.Api.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<Guid?> CreateAsync(CreateGenreDto createGenreDto)
        {
            var existingGenre = await _genreRepository.GetGenreByName(createGenreDto.Name);
            if(existingGenre != null) 
            {
                return null;
            }

            var genre = new Genre
            {
                GenreId = Guid.NewGuid(),
                Name = createGenreDto.Name
            };
            await _genreRepository.AddAsync(genre);
            return genre.GenreId;
        }

        public async Task<bool> DeleteAsync(DeleteGenreDto deleteGenreDto)
        {
            var deleteGenre = await _genreRepository.GetAsync(deleteGenreDto.GenreId);
            if(deleteGenre == null) 
            {
                return false;
            }
            await _genreRepository.DeleteAsync(deleteGenre);
            return true;
        }

        public async Task<IEnumerable<GenreDto>> GetAllAsync()
        {
            var genres=await _genreRepository.GetAllAsync();
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

        public async Task<bool> UpdateAsync(UpdateGenreDto updateGenreDto)
        {
            var genre = await _genreRepository.GetAsync(updateGenreDto.GenreId);
            if (genre == null)
            {
                return false;
            }

            var existingGenre = await _genreRepository.GetGenreByName(updateGenreDto.Name);
            if (existingGenre != null)
            {
                return false;
            }
            genre.Name= updateGenreDto.Name;

            await _genreRepository.UpdateAsync(genre);
            return true;
        }
    }
}
