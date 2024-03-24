using MediatR;

namespace MoviesRating.Application.Commands
{
    public class CreateMovieCommand:IRequest
    {
        public Guid MovieId { get; set; }
        public string Title { get; set; }
        public Guid GenreId { get; set; }
        public Guid DirectorId { get; set; }
        public int YearOfProduction { get; set; }
        public string Description { get; set; }
    }
}

