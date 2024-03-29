using MoviesRating.Domain.Exceptions;
namespace MoviesRating.Application.Exceptions
{
    public class MovieDoesNotExistException : MovieRatingException
    {
        public MovieDoesNotExistException() : base("Movie does not exist.")
        {
        }
    }
}
