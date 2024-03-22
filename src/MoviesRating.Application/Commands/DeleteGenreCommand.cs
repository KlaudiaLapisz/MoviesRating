using MediatR;

namespace MoviesRating.Application.Commands
{
    public class DeleteGenreCommand:IRequest
    {
        public Guid GenreId { get; set; }
    }
}
