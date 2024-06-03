using MoviesRating.Domain.Entities;

namespace MoviesRating.Application.Strategies
{
    public interface IRateMovieStrategy
    {
        bool RateExists { get; }
        Task RateMovie(User user, Movie movie, int value);
    }
}
