namespace MoviesRating.Domain.Exceptions
{
    public class EmptyFullNameException : MovieRatingException
    {
        public EmptyFullNameException() : base("Full name is empty")
        {
        }
    }
}
