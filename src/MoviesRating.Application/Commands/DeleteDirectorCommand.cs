using MediatR;

namespace MoviesRating.Application.Commands
{
    public class DeleteDirectorCommand:IRequest
    {
        public Guid DirectorId { get; set; }
    }
}
