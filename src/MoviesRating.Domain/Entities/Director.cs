namespace MoviesRating.Domain.Entities
{
    public class Director
    {
        public Guid DirectorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
