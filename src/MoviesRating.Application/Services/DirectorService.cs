using MoviesRating.Application.Commands;
using MoviesRating.Application.DTO.Directors;
using MoviesRating.Application.Exceptions;
using MoviesRating.Domain.Entities;
using MoviesRating.Domain.Repositories;

namespace MoviesRating.Application.Services
{
    internal class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;

        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }      
             

        public async Task<IEnumerable<DirectorDto>> GetAllAsync()
        {
            var directors = await _directorRepository.GetAllAsync();
            return directors.Select(d => new DirectorDto
            {
                DirectorId = d.DirectorId,
                FirstName = d.FirstName,
                LastName = d.LastName
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
    }
}
