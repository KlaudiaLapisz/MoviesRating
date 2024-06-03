using MediatR;
using MoviesRating.Application.Exceptions;
using MoviesRating.Application.Strategies;
using MoviesRating.Domain.Entities;
using MoviesRating.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Application.Commands.Handlers
{
    internal class RateMovieCommandHandler : IRequestHandler<RateMovieCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IRateRepository _ratingRepository;
        private readonly IEnumerable<IRateMovieStrategy> _rateMovieStrategies;

        public RateMovieCommandHandler(IUserRepository userRepository, IMovieRepository movieRepository, IRateRepository ratingRepository, IEnumerable<IRateMovieStrategy> rateMovieStrategies)
        {
            _userRepository = userRepository;
            _movieRepository = movieRepository;
            _ratingRepository = ratingRepository;
            _rateMovieStrategies = rateMovieStrategies;
        }

        public async Task Handle(RateMovieCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.UserId, cancellationToken);
            if(user== null)
            {
                throw new UserNotFoundException();
            }
            var movie = await _movieRepository.GetAsync(request.MovieId, cancellationToken);
            if(movie== null)
            {
                throw new MovieDoesNotExistException();
            }
            
            var rateExists = await _ratingRepository.ExistsAsync(request.UserId, request.MovieId, cancellationToken);
            var rateMovieStrategy = _rateMovieStrategies.Single(x => x.RateExists == rateExists);
            await rateMovieStrategy.RateMovie(user, movie, request.Value);
        }
    }
}
