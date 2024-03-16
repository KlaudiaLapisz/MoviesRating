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

        public Director(Guid directorId, string firstName, string lastName)
        {
            if (directorId == Guid.Empty)
            {
                throw new ArgumentException("Empty directorId");
            }
            DirectorId = directorId;

            ChangeFirstName(firstName);
            ChangeLastName(lastName);
        }

        public void ChangeFirstName(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
            {
                throw new ArgumentException("Empty first name");
            }

            if (firstName.Length > 20)
            {
                throw new ArgumentException("Max first name length exceeded");
            }

            FirstName = firstName;
        }

        public void ChangeLastName(string lastName)
        {
            if (string.IsNullOrEmpty(lastName))
            {
                throw new ArgumentException("Empty last name");
            }

            if (lastName.Length > 30)
            {
                throw new ArgumentException("Max last name length exceeded");
            }

            LastName = lastName;
        }

    }
}
