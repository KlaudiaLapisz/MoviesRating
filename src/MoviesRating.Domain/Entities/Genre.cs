namespace MoviesRating.Domain.Entities
{
    public class Genre
    {
        public Guid GenreId { get; set; }
        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
