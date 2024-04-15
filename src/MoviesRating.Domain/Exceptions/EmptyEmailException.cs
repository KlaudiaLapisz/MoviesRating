namespace MoviesRating.Domain.Exceptions
{
    public class EmptyEmailException : MovieRatingException
    {
        public EmptyEmailException() : base("Email is empty")
        {
        }
    }
}
