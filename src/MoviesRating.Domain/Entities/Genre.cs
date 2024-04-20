using MoviesRating.Domain.Exceptions;

namespace MoviesRating.Domain.Entities
{
    public class Genre
    {
        public Guid GenreId { get; }
        public string Name { get; private set; }

        public ICollection<Movie> Movies { get; set; }

        private Genre()
        {

        }

        internal Genre(Guid genreId, string name)
        {
            if (genreId == Guid.Empty)
            {
                throw new EmptyGenreIdException();
            }

            GenreId = genreId;

            ChangeName(name);
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new EmptyGenreNameException();
            }

            if (name.Length > 50)
            {
                throw new GenreNameLengthExceededException();
            }

            Name = name;
        }
    }
}
