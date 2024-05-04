namespace MoviesRating.Application.DTO.Movies
{
    public class MovieDto
    {
        public Guid MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int YearOfProduction { get; set; }
        public MovieDirectorDto Director { get; set; }
        public MovieGenreDto Genre { get; set; }
        public double Rate { get; set; }
    }
}
