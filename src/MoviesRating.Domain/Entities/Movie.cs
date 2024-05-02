using MoviesRating.Domain.Exceptions;

namespace MoviesRating.Domain.Entities
{
    public class Movie
    {
        public Guid MovieId { get; }
        public string Title { get; private set; }
        public Guid GenreId { get; private set; }
        public Guid DirectorId { get; private set; }
        public int YearOfProduction { get; private set; }
        public string Description { get; private set; }

        public Director Director { get; private set; }
        public Genre Genre { get; private set; }
        public ICollection<Rate> Rates { get; set; }

        private Movie()
        {

        }

        public Movie(Guid movieId, string title, int yearOfProduction, string description, Director director, Genre genre)
        {
            if (movieId == Guid.Empty)
            {
                throw new EmptyMovieIdException();
            }

            MovieId = movieId;

            ChangeTitle(title);
            ChangeYearOfProduction(yearOfProduction);
            ChangeDescription(description);
            ChangeDirector(director);
            ChangeGenre(genre);                   
        }

        public void ChangeTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new EmptyMovieTitleException();
            }

            if (title.Length > 50)
            {
                throw new MovieTitleLengthExceededException();
            }

            Title = title;
        }

        public void ChangeYearOfProduction(int yearOfProduction)
        {
            if (yearOfProduction < 1900)
            {
                throw new IncorrectYearOfProductionException();
            }

            YearOfProduction = yearOfProduction;
        }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new EmptyMovieDescriptionException();
            }
            if (description.Length > 1000)
            {
                throw new MovieDescriptionLengthExceededException();
            }

            Description = description;
        }
        public void ChangeDirector(Director director)
        {
            if (director == null)
            {
                throw new EmptyMovieDirectorException();
            }

            Director = director;
        }
        public void ChangeGenre(Genre genre)
        {
            if (genre == null)
            {
                throw new EmptyMovieGenreException();
            }

            Genre = genre;
        }
    }
}
