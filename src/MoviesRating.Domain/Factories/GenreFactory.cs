using MoviesRating.Domain.Entities;

namespace MoviesRating.Domain.Factories
{
    internal class GenreFactory : IGenreFactory
    {
        public Genre CreateGenre(Guid genreId, string genreName)
        {
            var genre = new Genre(genreId, genreName);

            return genre;
        }
    }
}
