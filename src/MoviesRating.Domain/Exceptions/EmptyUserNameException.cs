namespace MoviesRating.Domain.Exceptions
{
    public class EmptyUserNameException : MovieRatingException
    {
        public EmptyUserNameException() : base("Username is empty")
        {
        }
    }
}
