using MoviesRating.Domain.Exceptions;
namespace MoviesRating.Application.Exceptions
{
    public class MovieExistException : MovieRatingException
    {
        public MovieExistException() : base("Movie is already exist.")
        {

        }
    }
}
