using MediatR;

namespace MoviesRating.Application.Commands
{
    public class UpdateDirectorCommand:IRequest
    {
        public Guid DirectorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
