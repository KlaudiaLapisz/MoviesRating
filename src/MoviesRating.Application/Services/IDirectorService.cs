using MoviesRating.Application.DTO.Directors;

namespace MoviesRating.Application.Services
{
    public interface IDirectorService
    {
        Task<Guid> CreateAsync(CreateDirectorDto createDirectorDto);
        Task UpdateAsync(UpdateDirectorDto updateDirectorDto);
        Task DeleteAsync(DeleteDirectorDto deleteDirectorDto);
        Task<IEnumerable<DirectorDto>> GetAllAsync();
        Task<DirectorDto> GetAsync(Guid id);
    }
}
