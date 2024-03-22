using MoviesRating.Application.Commands;
using MoviesRating.Application.DTO.Genres;

namespace MoviesRating.Application.Services
{
    public interface IGenreService
    {              
        Task<IEnumerable<GenreDto>> GetAllAsync();
        Task<GenreDto> GetAsync(Guid id);
    }
}
