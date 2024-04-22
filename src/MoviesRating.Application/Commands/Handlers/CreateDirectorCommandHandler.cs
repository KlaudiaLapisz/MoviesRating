using MediatR;
using MoviesRating.Application.Exceptions;
using MoviesRating.Domain.Entities;
using MoviesRating.Domain.Factories;
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
        private readonly IDirectorFactory _directorFactory;

        public CreateDirectorCommandHandler(IDirectorRepository directorRepository, IDirectorFactory directorFactory)
        {
            _directorRepository = directorRepository;
            _directorFactory = directorFactory;
        }

        public async Task Handle(CreateDirectorCommand request, CancellationToken cancellationToken)
        {
            var existingDirector = await _directorRepository.GetDirectorByFirstNameAndLastName(request.FirstName, request.LastName);
            if (existingDirector != null)
            {
                throw new DirectorExistException();
            }

            var director = _directorFactory.CreateDirector(request.DirectorId, request.FirstName, request.LastName);
            await _directorRepository.AddAsync(director);           
        }
    }
}
