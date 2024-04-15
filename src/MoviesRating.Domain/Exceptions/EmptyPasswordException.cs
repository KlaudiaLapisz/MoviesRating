namespace MoviesRating.Domain.Exceptions
{
    public class EmptyPasswordException : MovieRatingException
    {
        public EmptyPasswordException() : base("Password is empty")
        {
        }
    }
}
