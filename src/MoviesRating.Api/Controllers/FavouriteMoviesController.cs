using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesRating.Application.Commands;
using MoviesRating.Application.DTO.Movies;
using MoviesRating.Application.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace MoviesRating.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class FavouriteMovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FavouriteMovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Added favourite movie")]
        public async Task<ActionResult> Post(AddFavouriteMovieCommand command, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(User.Identity?.Name);
            command.Id = Guid.NewGuid();
            command.UserId = userId;
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{movieId:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Delete favourite movie")]
        public async Task<ActionResult> Delete(Guid movieId, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(User.Identity?.Name);
            var command = new DeleteFavouriteMovieCommand { UserId = userId, MovieId = movieId };
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Get favourite movies list")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAll([FromQuery] GetAllFavouriteMoviesQuery query, CancellationToken cancellationToken)
        {
            var userId = Guid.Parse(User.Identity?.Name);
            query.UserId = userId;
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

    }
}

