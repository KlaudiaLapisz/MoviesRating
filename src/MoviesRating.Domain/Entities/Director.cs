using MoviesRating.Domain.Exceptions;

namespace MoviesRating.Domain.Entities
{
    public class Director
    {
        public Guid DirectorId { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public ICollection<Movie> Movies { get; set; }

        private Director()
        {

        }

        internal Director(Guid directorId, string firstName, string lastName)
        {
            if (directorId == Guid.Empty)
            {
                throw new EmptyDirectorIdException();
            }
            DirectorId = directorId;

            ChangeFirstName(firstName);
            ChangeLastName(lastName);
        }

        public void ChangeFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new EmptyDirectorFirstNameException();
            }

            if (firstName.Length > 20)
            {
                throw new DirectorFirstNameLengthExceededException();
            }

            FirstName = firstName;
        }

        public void ChangeLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                throw new EmptyDirectorLastNameException();
            }

            if (lastName.Length > 30)
            {
                throw new DirectorLastNameLengthExceededException();
            }

            LastName = lastName;
        }

    }
}
