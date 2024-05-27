using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesRating.Application.Commands;
using Swashbuckle.AspNetCore.Annotations;

namespace MoviesRating.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class FavouriteMovieController:ControllerBase
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
            command.Id=Guid.NewGuid();
            command.UserId = userId;
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

    }
}
