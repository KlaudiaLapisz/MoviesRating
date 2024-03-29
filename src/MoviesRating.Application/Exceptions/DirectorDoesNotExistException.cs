using MoviesRating.Domain.Exceptions;
namespace MoviesRating.Application.Exceptions
{
    public class DirectorDoesNotExistException : MovieRatingException
    {
        public DirectorDoesNotExistException() : base("Director does not exist.")
        {
        }
    }
}
