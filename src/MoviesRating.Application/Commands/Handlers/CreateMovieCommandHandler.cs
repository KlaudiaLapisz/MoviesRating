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
    internal class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IDirectorRepository _directorRepository;

        public CreateMovieCommandHandler(IMovieRepository movieRepository, IDirectorRepository directorRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _directorRepository = directorRepository;
        }

        public async Task Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {

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

            var movie = new Movie(request.MovieId, request.Title, request.YearOfProduction, request.Description, director, genre);
            await _movieRepository.AddAsync(movie);            
        }
    }
}
