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
    internal class DeleteDirectorCommandHandler : IRequestHandler<DeleteDirectorCommand>
    {
        private readonly IDirectorRepository _directorRepository;

        public DeleteDirectorCommandHandler(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }

        public async Task Handle(DeleteDirectorCommand request, CancellationToken cancellationToken)
        {
            var deleteDirector = await _directorRepository.GetAsync(request.DirectorId, cancellationToken);
            if (deleteDirector == null)
            {
                throw new DirectorDoesNotExistException();
            }
            await _directorRepository.DeleteAsync(deleteDirector, cancellationToken);
        }
    }
}
