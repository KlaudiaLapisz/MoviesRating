using MediatR;
using MoviesRating.Application.Exceptions;
using MoviesRating.Domain.Entities;
using MoviesRating.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Commands.Handlers
{
    internal class CreateDirectorCommandHandler : IRequestHandler<CreateDirectorCommand>
    {
        private readonly IDirectorRepository _directorRepository;

        public CreateDirectorCommandHandler(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public async Task Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
        {
            var existingDirector = await _directorRepository.GetDirectorByFirstNameAndLastName(request.FirstName, request.LastName);
            if (existingDirector != null)
            {
                throw new DirectorExistException();
            }

            var director = new Director(Guid.NewGuid(), request.FirstName, request.LastName);
            await _directorRepository.AddAsync(director);           
        }
    }
}
