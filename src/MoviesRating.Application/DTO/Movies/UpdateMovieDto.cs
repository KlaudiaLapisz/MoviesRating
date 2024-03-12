namespace MoviesRating.Application.DTO.Movies
{
    public class UpdateMovieDto
    {
        public Guid MovieId { get; set; }
        public string Title { get; set; }
        public int YearOfProduction { get; set; }
        public string Description { get; set; }
        public Guid DirectorId { get; set; }
        public Guid GenreId { get; set; }
    }
}
