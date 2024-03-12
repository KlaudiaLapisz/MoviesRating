using MoviesRating.Application.DTO.Directors;

namespace MoviesRating.Application.Services
{
    public interface IDirectorService
    {
        Task<Guid?> CreateAsync(CreateDirectorDto createDirectorDto);
        Task<bool> UpdateAsync(UpdateDirectorDto updateDirectorDto);
        Task<bool> DeleteAsync(DeleteDirectorDto deleteDirectorDto);
        Task<IEnumerable<DirectorDto>> GetAllAsync();
        Task<DirectorDto> GetAsync(Guid id);
    }
}
