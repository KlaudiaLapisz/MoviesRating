using MoviesRating.Api.DTO.Movies;

namespace MoviesRating.Api.Services
{
    public interface IMovieService
    {
        Task <Guid?> CreateAsync(CreateMovieDto createMovieDto);
        Task <bool> UpdateAsync (UpdateMovieDto updateMovieDto);
        Task <bool> DeleteAsync (DeleteMovieDto deleteMovieDto);
        Task<IEnumerable<MovieDto>> GetAllAsync();
        Task<MovieDto> GetAsync(Guid id);
    }
}
