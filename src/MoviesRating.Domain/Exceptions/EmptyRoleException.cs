namespace MoviesRating.Domain.Exceptions
{
    public class EmptyRoleException : MovieRatingException
    {
        public EmptyRoleException() : base("Role is empty")
        {
        }
    }
}
