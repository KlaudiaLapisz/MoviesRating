using MediatR;

namespace MoviesRating.Application.Commands
{
    public class CreateGenreCommand : IRequest
    {
        public Guid GenreId { get; set; }
        public string Name { get; set; }
    }
}
