using MoviesRating.Api.DTO.Directors;

namespace MoviesRating.Api.Services
{
    public interface IDirectorService
    {
        Task<Guid?> CreateAsync(CreateDirectorDto createDirectorDto);
        Task<bool> UpdateAsync (UpdateDirectorDto updateDirectorDto);
        Task<bool> DeleteAsync (DeleteDirectorDto deleteDirectorDto);
        Task<IEnumerable<DirectorDto>> GetAllAsync ();
        Task<DirectorDto> GetAsync(Guid id);
    }
}
