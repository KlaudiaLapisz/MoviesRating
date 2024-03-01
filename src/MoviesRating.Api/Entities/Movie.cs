namespace MoviesRating.Api.Entities
{
    public class Movie
    {
        public Guid MovieId {  get; set; }
        public string Title { get; set; }
        public Guid GenreId { get; set; }
        public Guid DirectorId { get; set; }
        public int YearOfProduction { get; set; }

        public Director Director { get; set; }
        public Genre Genre { get; set; }
    }
}
