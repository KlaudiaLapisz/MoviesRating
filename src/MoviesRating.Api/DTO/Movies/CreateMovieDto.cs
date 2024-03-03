namespace MoviesRating.Api.DTO.Movies
{
    public class CreateMovieDto
    {
        public string Title { get; set; }
        public Guid GenreId { get; set; }
        public Guid DirectorId { get; set; }
        public int YearOfProduction { get; set; }
        public string Description { get; set; }
    }
}

