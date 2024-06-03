using MoviesRating.Domain.Entities;
using MoviesRating.Domain.Repositories;

namespace MoviesRating.Application.Strategies
{
    internal class RateNotExistMovieStrategy : IRateMovieStrategy
    {
        private readonly IRateRepository _ratingRepository;

        public RateNotExistMovieStrategy(IRateRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public bool RateExists => false;

        public async Task RateMovie(User user, Movie movie, int value)
        {
            var rate = new Rate(Guid.NewGuid(), value, user, movie);
            await _ratingRepository.AddAsync(rate);
        }
    }
}
