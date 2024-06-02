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
    public class DeleteMovieToWatchCommandHandler : IRequestHandler<DeleteMovieToWatchCommand>
    {
        private readonly IMovieToWatchRepository _movieToWatchRepository;

        public DeleteMovieToWatchCommandHandler(IMovieToWatchRepository movieToWatchRepository)
        {
            _movieToWatchRepository = movieToWatchRepository;
        }

        public async Task Handle(DeleteMovieToWatchCommand request, CancellationToken cancellationToken)
        {
            var deleteMovieToWatch = await _movieToWatchRepository.GetAsync(request.UserId, request.MovieId, cancellationToken);
            if (deleteMovieToWatch == null)
            {
                throw new MovieDoesNotExistException();
            }
            await _movieToWatchRepository.DeleteAsync(deleteMovieToWatch, cancellationToken);
        }
    }
}
