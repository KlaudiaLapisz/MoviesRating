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
    internal class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand>
    {
        private readonly IGenreRepository _genreRepository;

        public CreateGenreCommandHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var existingGenre = await _genreRepository.GetGenreByName(request.Name);
            if (existingGenre != null)
            {
                throw new GenreExistException();
            }

            var genre = new Genre(request.GenreId, request.Name);
            await _genreRepository.AddAsync(genre);
        }
    }
}
