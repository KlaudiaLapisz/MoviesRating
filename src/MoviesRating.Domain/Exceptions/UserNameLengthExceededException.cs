namespace MoviesRating.Domain.Exceptions
{
    public class UserNameLengthExceededException : MovieRatingException
    {
        public UserNameLengthExceededException() : base("Username length exceeded.")
        {

        }
    }
}
