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
    internal class RateMovieCommandHandler : IRequestHandler<RateMovieCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IRateRepository _ratingRepository;

        public RateMovieCommandHandler(IUserRepository userRepository, IMovieRepository movieRepository, IRateRepository ratingRepository)
        {
            _userRepository = userRepository;
            _movieRepository = movieRepository;
            _ratingRepository = ratingRepository;
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
            var rate= await _ratingRepository.GetAsync(request.UserId, request.MovieId, cancellationToken);
            if(rate==null)
            {
                rate=new Rate(request.Id, request.Value, user, movie);
                await _ratingRepository.AddAsync(rate, cancellationToken);
            }
            else
            {
                rate.UpdateValue(request.Value);
                await _ratingRepository.UpdateAsync(rate, cancellationToken);
            }


        }
    }
}
