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
    internal class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand>
    {
        private readonly IGenreRepository _genreRepository;

        public UpdateGenreCommandHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task Handle(UpdateGenreCommand request, CancellationToken cancellationToken)
        {
            var genre = await _genreRepository.GetAsync(request.GenreId, cancellationToken);
            if (genre == null)
            {
                throw new GenreDoesNotExistException();
            }

            var existingGenre = await _genreRepository.GetGenreByName(request.Name, cancellationToken);
            if (existingGenre != null)
            {
                throw new GenreDoesNotExistException();
            }
            genre.ChangeName(request.Name);

            await _genreRepository.UpdateAsync(genre, cancellationToken);
        }
    }
}
