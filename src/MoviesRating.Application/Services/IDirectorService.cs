using MoviesRating.Application.Commands;
using MoviesRating.Application.DTO.Directors;

namespace MoviesRating.Application.Services
{
    public interface IDirectorService
    {
        Task UpdateAsync(UpdateDirectorDto updateDirectorDto);      
        Task<IEnumerable<DirectorDto>> GetAllAsync();
        Task<DirectorDto> GetAsync(Guid id);
    }
}
