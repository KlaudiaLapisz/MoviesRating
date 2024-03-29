using MoviesRating.Domain.Exceptions;
namespace MoviesRating.Application.Exceptions
{
    public class DirectorExistException : MovieRatingException
    {
        public DirectorExistException() : base("Director is already existing.")
        {
        }
    }
}
