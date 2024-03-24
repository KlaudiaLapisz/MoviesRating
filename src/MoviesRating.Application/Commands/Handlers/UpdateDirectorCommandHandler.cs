using MediatR;
using MoviesRating.Application.Exceptions;
using MoviesRating.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Commands.Handlers
{
    internal class UpdateDirectorCommandHandler : IRequestHandler<UpdateDirectorCommand>
    {
        private readonly IDirectorRepository _directorRepository;

        public UpdateDirectorCommandHandler(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public async Task Handle(UpdateDirectorCommand request, CancellationToken cancellationToken)
        {
            var director = await _directorRepository.GetAsync(request.DirectorId);
            if (director == null)
            {
                throw new DirectorDoesNotExistException();
            }

            var existingDirector = await _directorRepository.GetDirectorByFirstNameAndLastName(request.FirstName, request.LastName);
            if (existingDirector != null)
            {
                throw new DirectorExistException();
            }

            director.ChangeFirstName(request.FirstName);
            director.ChangeLastName(request.LastName);

            await _directorRepository.UpdateAsync(director);
        }
    }
}
