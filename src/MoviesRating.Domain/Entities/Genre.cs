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

        public Genre(Guid genreId, string name)
        {
            if (genreId == Guid.Empty)
            {
                throw new ArgumentException("Empty genreId");
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Empty genre name");
            }

            if (name.Length > 50)
            {
                throw new ArgumentException("Max genre name length exceeded");
            }

            GenreId = genreId;
            Name = name;
        }

        public void ChangeName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Empty genre name");
            }

            Name = name;
        }
    }
}
