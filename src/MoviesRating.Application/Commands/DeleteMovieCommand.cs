using MediatR;

namespace MoviesRating.Application.Commands
{
    public class DeleteMovieCommand:IRequest
    {
        public Guid MovieId { get; set; }
    }
}
