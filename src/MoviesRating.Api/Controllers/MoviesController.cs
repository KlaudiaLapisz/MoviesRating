using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoviesRating.Application.Commands;
using MoviesRating.Application.DTO.Movies;
using MoviesRating.Application.Services;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MoviesRating.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController:ControllerBase
    {
        private readonly IMovieService _movieService;
        private readonly IMediator _mediator;

        public MoviesController(IMovieService movieService, IMediator mediator)
        {
            _movieService = movieService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAll()
        {
            var result = await _movieService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MovieDto>> Get(Guid id)
        {
            var result = await _movieService.GetAsync(id);
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
        public async Task<ActionResult> Put (Guid id, UpdateMovieDto updateMovieDto)
        {
            updateMovieDto.MovieId = id;
            await _movieService.UpdateAsync(updateMovieDto);
            
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteMovieDto = new DeleteMovieDto { MovieId = id };
            await _movieService.DeleteAsync(deleteMovieDto);
            
            return NoContent();
        }
    }
}
