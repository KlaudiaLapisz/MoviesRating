using MediatR;
using MoviesRating.Application.DTO.Movies;
using MoviesRating.Application.Queries.Shared;

namespace MoviesRating.Application.Queries
{
    public class GetAllFavouriteMoviesQuery: IRequest<PagedList<MovieDto>>
    {
        public Guid UserId { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
