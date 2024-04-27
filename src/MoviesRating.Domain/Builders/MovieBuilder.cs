using MoviesRating.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Builders
{
    public class MovieBuilder
    {
        private Guid _movieId;
        private string _title;
        private int _yearOfProduction;
        private string _description;
        private Director _director;
        private Genre _genre;

        public MovieBuilder AddMovieId(Guid movieId)
        {
            _movieId = movieId;

            return this;
        }

        public MovieBuilder AddTitle(string title)
        {
            _title = title;

            return this;
        }

        public MovieBuilder AddYearOfProduction(int yearOfProduction)
        {
            _yearOfProduction = yearOfProduction;

            return this;
        }

        public MovieBuilder AddDescription(string description)
        {
            _description = description;

            return this;
        }

        public MovieBuilder AddDirector(Director director)
        {
            _director = director;

            return this;
        }

        public MovieBuilder AddGenre(Genre genre)
        {
            _genre = genre;

            return this;
        }

        public Movie Create()
        {
            return new Movie(_movieId, _title, _yearOfProduction, _description, _director, _genre);
        }
    }
}
