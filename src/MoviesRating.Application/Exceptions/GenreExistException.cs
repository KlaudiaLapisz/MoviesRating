using MoviesRating.Domain.Exceptions;
namespace MoviesRating.Application.Exceptions
{
    public class GenreExistException : MovieRatingException
    {
        public GenreExistException() : base("Genre is already existing.")
        {

        }
    }
}
