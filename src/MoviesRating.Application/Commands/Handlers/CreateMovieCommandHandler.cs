﻿using MediatR;
using MoviesRating.Application.Exceptions;
using MoviesRating.Domain.Builders;
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

            var existingMovie = await _movieRepository.GetMovieByTitleAndYearOfProductionAsync(request.Title, request.YearOfProduction, cancellationToken);
            if (existingMovie != null)
            {
                throw new MovieExistException();
            }

            var director = await _directorRepository.GetAsync(request.DirectorId, cancellationToken);
            if (director == null)
            {
                throw new DirectorDoesNotExistException();
            }

            var genre = await _genreRepository.GetAsync(request.GenreId, cancellationToken);
            if (genre == null)
            {
                throw new GenreDoesNotExistException();
            }

            var movieBuilder = new MovieBuilder();
            movieBuilder.AddMovieId(request.MovieId)
                .AddTitle(request.Title)
                .AddYearOfProduction(request.YearOfProduction)
                .AddDescription(request.Description)
                .AddDirector(director)
                .AddGenre(genre);
            var movie = movieBuilder.Create();
            await _movieRepository.AddAsync(movie, cancellationToken);            
        }
    }
}
