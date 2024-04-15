namespace MoviesRating.Domain.Exceptions
{
    public class EmailLengthExceededException : MovieRatingException
    {
        public EmailLengthExceededException() : base("Email length exceeded.")
        {

        }
    }
}
