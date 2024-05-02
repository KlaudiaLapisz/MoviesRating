using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesRating.Domain.Entities
{
    public class Rate
    {
        public Guid Id { get; }
        public Guid UserId { get; private set; }
        public Guid MovieId { get; private set; }
        public int Value { get; private set; }
        public User User { get; private set; }
        public Movie Movie { get; private set; }

        private Rate()
        {

        }

        public Rate (Guid id, int value, User user, Movie movie)
        {           
            Id = id;
            Value = value;
            User = user;
            Movie = movie;
        }

        public void UpdateValue(int value)
        {
            Value = value;
        }
    }
}
