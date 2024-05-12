using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesRating.Application.Commands;
using MoviesRating.Application.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace MoviesRating.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RatesController:ControllerBase
    {
        private readonly IMediator _mediator;

        public RatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Add a rating")]
        public async Task<ActionResult> Post(RateMovieCommand command)
        {
            var userId = Guid.Parse(User.Identity?.Name);
            command.Id = Guid.NewGuid();
            command.UserId = userId;

            await _mediator.Send(command);

            return Ok();
        }

        [HttpGet("movies")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation("Get a ranking of top films")]
        public async Task<ActionResult> GetTopMovies([FromQuery] GetTopMoviesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
