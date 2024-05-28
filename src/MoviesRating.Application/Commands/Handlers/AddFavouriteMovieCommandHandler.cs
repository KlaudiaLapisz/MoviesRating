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
    internal class AddFavouriteMovieCommandHandler : IRequestHandler<AddFavouriteMovieCommand>
    {
        private readonly IFavouriteMovieRepository _favouriteMovieRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IUserRepository _userRepository;

        public AddFavouriteMovieCommandHandler(IFavouriteMovieRepository favouriteMovieRepository, IMovieRepository movieRepository, IUserRepository userRepository)
        {
            _favouriteMovieRepository = favouriteMovieRepository;
            _movieRepository = movieRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(AddFavouriteMovieCommand request, CancellationToken cancellationToken)
        {
            var movie= await _movieRepository.GetAsync(request.MovieId, cancellationToken);
            if(movie== null)
            {
                throw new MovieDoesNotExistException();
            }
            var user= await _userRepository.GetUserByIdAsync(request.UserId, cancellationToken);
            if(user== null)
            {
                throw new UserNotFoundException();
            }
            var existingFavouriteMovie = await _favouriteMovieRepository.GetFavouriteMovieAsync(request.UserId, request.MovieId, cancellationToken);
            if(existingFavouriteMovie!=null)
            {
                throw new FavouriteMovieAlreadyAddedException();
            }
            var favouriteMovie = new FavouriteMovie(request.Id, user, movie);
            await _favouriteMovieRepository.AddAsync(favouriteMovie, cancellationToken);
        }
    }
}
