using MoviesRating.Application.DTO.Genres;

namespace MoviesRating.Application.Services
{
    public interface IGenreService
    {
        Task<Guid?> CreateAsync(CreateGenreDto createGenreDto);
        Task<bool> UpdateAsync(UpdateGenreDto updateGenreDto);
        Task<bool> DeleteAsync(DeleteGenreDto deleteGenreDto);
        Task<IEnumerable<GenreDto>> GetAllAsync();
        Task<GenreDto> GetAsync(Guid id);
    }
}
