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
    internal class AddMovieToWatchCommandHandler:IRequestHandler<AddMovieToWatchCommand>
    {
        private readonly IMovieToWatchRepository _movieToWatchRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;

        public AddMovieToWatchCommandHandler(IMovieToWatchRepository movieToWatchRepository, IMovieRepository movieRepository, IUserRepository userRepository)
        {
            _movieToWatchRepository = movieToWatchRepository;
            _movieRepository = movieRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(AddMovieToWatchCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetAsync(request.MovieId, cancellationToken);
            if (movie == null)
            {
                throw new MovieDoesNotExistException();
            }
            var user = await _userRepository.GetUserByIdAsync(request.UserId, cancellationToken);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            var existingMovieToWatch = await _movieToWatchRepository.GetAsync(request.UserId, request.MovieId, cancellationToken);
            if(existingMovieToWatch != null)
            {
                throw new MovieToWatchAlreadyAddedException();
            }
            var movieToWatch = new MovieToWatch(request.Id, user, movie);
            await _movieToWatchRepository.AddAsync(movieToWatch, cancellationToken);
        }
    }
}
