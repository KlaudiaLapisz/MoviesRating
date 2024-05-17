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
    internal class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand>
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IGenreFactory _genreFactory;

        public CreateGenreCommandHandler(IGenreRepository genreRepository, IGenreFactory genreFactory)
        {
            _genreRepository = genreRepository;
            _genreFactory = genreFactory;
        }

        public async Task Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var existingGenre = await _genreRepository.GetGenreByName(request.Name, cancellationToken);
            if (existingGenre != null)
            {
                throw new GenreExistException();
            }

            var genre = _genreFactory.CreateGenre(request.GenreId, request.Name);
            await _genreRepository.AddAsync(genre, cancellationToken);
        }
    }
}
