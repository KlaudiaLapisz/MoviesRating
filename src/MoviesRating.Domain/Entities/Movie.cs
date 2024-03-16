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

        private Movie()
        {

        }

        public Movie(Guid movieId, string title, int yearOfProduction, string description, Director director, Genre genre)
        {
            if (movieId == Guid.Empty)
            {
                throw new ArgumentException("Empty movieId");
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
                throw new ArgumentException("Title is empty");
            }

            if (title.Length > 50)
            {
                throw new ArgumentException("Title is too long");
            }

            Title = title;
        }

        public void ChangeYearOfProduction(int yearOfProduction)
        {
            if (yearOfProduction < 1900)
            {
                throw new ArgumentException("Incorrect year of production");
            }

            YearOfProduction = yearOfProduction;
        }

        public void ChangeDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("Description is empty");
            }
            if (description.Length > 1000)
            {
                throw new ArgumentException("Description is too long");
            }

            Description = description;
        }
        public void ChangeDirector(Director director)
        {
            if (director == null)
            {
                throw new ArgumentException("Director does not exist");
            }

            Director = director;
        }
        public void ChangeGenre(Genre genre)
        {
            if (genre == null)
            {
                throw new ArgumentException("Genre does not exist");
            }

            Genre = genre;
        }
    }
}
