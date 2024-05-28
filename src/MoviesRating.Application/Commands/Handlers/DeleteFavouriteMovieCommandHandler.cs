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
    public class DeleteFavouriteMovieCommandHandler : IRequestHandler<DeleteFavouriteMovieCommand>
    {
        private readonly IFavouriteMovieRepository _favouriteMovieRepository;

        public DeleteFavouriteMovieCommandHandler(IFavouriteMovieRepository favouriteMovieRepository)
        {
            _favouriteMovieRepository = favouriteMovieRepository;
        }

        public async Task Handle(DeleteFavouriteMovieCommand request, CancellationToken cancellationToken)
        {
           var deleteFavouriteMovie= await _favouriteMovieRepository.GetFavouriteMovieAsync(request.UserId, request.MovieId, cancellationToken);
            if(deleteFavouriteMovie == null)
            {
                throw new MovieDoesNotExistException();
            }
            await _favouriteMovieRepository.DeleteAsync(deleteFavouriteMovie, cancellationToken);
        }
    }
}
