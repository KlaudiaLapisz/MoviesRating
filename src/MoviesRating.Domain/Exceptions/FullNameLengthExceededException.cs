namespace MoviesRating.Domain.Exceptions
{
    public class FullNameLengthExceededException : MovieRatingException
    {
        public FullNameLengthExceededException() : base("Full name length exceeded.")
        {

        }
    }
}
