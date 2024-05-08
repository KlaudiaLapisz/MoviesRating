using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesRating.Application.Commands;
using MoviesRating.Application.Queries;

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
        public async Task<ActionResult> GetTopMovies([FromQuery] GetTopMoviesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
