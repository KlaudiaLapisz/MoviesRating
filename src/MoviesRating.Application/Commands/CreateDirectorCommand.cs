using MediatR;

namespace MoviesRating.Application.Commands
{
    public class CreateDirectorCommand:IRequest
    {
        public Guid DirectorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
