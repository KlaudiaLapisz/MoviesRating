using MoviesRating.Domain.Exceptions;
namespace MoviesRating.Application.Exceptions
{
    public class GenreDoesNotExistException : MovieRatingException
    {
        public GenreDoesNotExistException() : base("Genre does not exist.")
        {
        }
    }
}
