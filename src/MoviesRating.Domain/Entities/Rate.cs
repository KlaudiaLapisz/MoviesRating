using MoviesRating.Domain.Exceptions;
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
            if(user == null)
            {
                throw new InvalidUserException();
            }

            if(movie == null)
            {
                throw new InvalidMovieException();
            }           

            Id = id;            
            User = user;
            Movie = movie;
            UpdateValue(value);
        }

        public void UpdateValue(int value)
        {
            if (value > 10 || value < 1)
            {
                throw new InvalidValueException();
            }

            Value = value;
        }
    }
}
