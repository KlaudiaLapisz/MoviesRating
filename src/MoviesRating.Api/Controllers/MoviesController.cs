using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoviesRating.Application.Commands;
using MoviesRating.Application.DTO.Movies;
using MoviesRating.Application.Queries;
namespace MoviesRating.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController:ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetAllMoviesQuery());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MovieDto>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetMovieByIdQuery() { Id = id });
            if(result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post (CreateMovieCommand command)
        {
            command.MovieId = Guid.NewGuid();
            await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { id=command.MovieId }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put (Guid id, UpdateMovieCommand command)
        {
            command.MovieId = id;
            await _mediator.Send(command);
            
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteMovieCommand { MovieId = id };
            await _mediator.Send(command);
            
            return NoContent();
        }
    }
}
