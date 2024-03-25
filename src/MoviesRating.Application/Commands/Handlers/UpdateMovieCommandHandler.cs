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
    internal class UpdateMovieCommandHandler : IRequestHandler<UpdateMovieCommand>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IDirectorRepository _directorRepository;

        public UpdateMovieCommandHandler(IMovieRepository movieRepository, IDirectorRepository directorRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _directorRepository = directorRepository;
            _genreRepository = genreRepository;
        }

        public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var movie = await _movieRepository.GetAsync(request.MovieId);
            if (movie == null)
            {
                throw new MovieDoesNotExistException();
            }

            var existingMovie = await _movieRepository.GetMovieByTitleAndYearOfProductionAsync(request.Title, request.YearOfProduction);
            if (existingMovie != null)
            {
                throw new MovieExistException();
            }

            var director = await _directorRepository.GetAsync(request.DirectorId);
            if (director == null)
            {
                throw new DirectorDoesNotExistException();
            }

            var genre = await _genreRepository.GetAsync(request.GenreId);
            if (genre == null)
            {
                throw new GenreDoesNotExistException();
            }

            movie.ChangeTitle(request.Title);
            movie.ChangeDescription(request.Description);
            movie.ChangeYearOfProduction(request.YearOfProduction);
            movie.ChangeDirector(director);
            movie.ChangeGenre(genre);

            await _movieRepository.UpdateAsync(movie);
        }
    }
}
