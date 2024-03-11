using MoviesRating.Api.DTO.Directors;
using MoviesRating.Domain.Entities;
using MoviesRating.Domain.Repositories;

namespace MoviesRating.Api.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public async Task<Guid?> CreateAsync(CreateDirectorDto createDirectorDto)
        {
            var existingDirector = await _directorRepository.GetDirectorByFirstNameAndLastName(createDirectorDto.FirstName, createDirectorDto.LastName);
            if(existingDirector != null) 
            {
                return null;
            }

            var director = new Director
            {
                DirectorId = Guid.NewGuid(),
                FirstName = createDirectorDto.FirstName,
                LastName = createDirectorDto.LastName
            };
            await _directorRepository.AddAsync(director);
            return director.DirectorId;
        }

        public async Task<bool> DeleteAsync(DeleteDirectorDto deleteDirectorDto)
        {
            var deleteDirector=await _directorRepository.GetAsync(deleteDirectorDto.DirectorId);
            if(deleteDirector == null)
            {
                return false;
            }
            await _directorRepository.DeleteAsync(deleteDirector);
            return true;
        }

        public async Task<IEnumerable<DirectorDto>> GetAllAsync()
        {
            var directors = await _directorRepository.GetAllAsync();
            return directors.Select(d => new DirectorDto
            {
                DirectorId=d.DirectorId,
                FirstName=d.FirstName,
                LastName=d.LastName
            });
        }

        public async Task<DirectorDto> GetAsync(Guid id)
        {
            var director = await _directorRepository.GetAsync(id);
            return new DirectorDto
            {
                DirectorId = director.DirectorId,
                FirstName = director.FirstName,
                LastName = director.LastName
            };
        }

        public async Task<bool> UpdateAsync(UpdateDirectorDto updateDirectorDto)
        {
            var director = await _directorRepository.GetAsync(updateDirectorDto.DirectorId);
            if(director==null)
            {
                return false;
            }

            var existingMovie = await _directorRepository.GetDirectorByFirstNameAndLastName(updateDirectorDto.FirstName, updateDirectorDto.LastName);
            if (existingMovie != null)
            {
                return false;
            }

            director.FirstName= updateDirectorDto.FirstName;
            director.LastName= updateDirectorDto.LastName;

            await _directorRepository.UpdateAsync(director);
            return true;
        }
    }
}
