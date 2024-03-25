using MoviesRating.Application.Commands;
using MoviesRating.Application.DTO.Movies;

namespace MoviesRating.Application.Services
{
    public interface IMovieService
    {     
        Task<IEnumerable<MovieDto>> GetAllAsync();
        Task<MovieDto> GetAsync(Guid id);
    }
}
