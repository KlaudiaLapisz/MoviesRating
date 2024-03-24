using MoviesRating.Application.Commands;
using MoviesRating.Application.DTO.Directors;

namespace MoviesRating.Application.Services
{
    public interface IDirectorService
    {
        Task<IEnumerable<DirectorDto>> GetAllAsync();
        Task<DirectorDto> GetAsync(Guid id);
    }
}
