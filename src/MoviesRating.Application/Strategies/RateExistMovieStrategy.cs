using MoviesRating.Domain.Entities;
using MoviesRating.Domain.Repositories;

namespace MoviesRating.Application.Strategies
{
    internal class RateExistMovieStrategy : IRateMovieStrategy
    {
        private readonly IRateRepository _ratingRepository;

        public RateExistMovieStrategy(IRateRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }

        public bool RateExists => true;

        public async Task RateMovie(User user, Movie movie, int value)
        {
            var rate = await _ratingRepository.GetAsync(user.UserId, movie.MovieId);
            rate.UpdateValue(value);
            await _ratingRepository.UpdateAsync(rate);
        }
    }
}
