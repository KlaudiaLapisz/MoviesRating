using Microsoft.AspNetCore.Mvc;
using MoviesRating.Api.DTO.Movies;
using MoviesRating.Api.Services;

namespace MoviesRating.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController:ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
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
        public async Task<ActionResult> Post (CreateMovieDto createMovieDto)
        {
            var id = await _movieService.CreateAsync(createMovieDto);
            if (id==null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(Get), new { id }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put (Guid id, UpdateMovieDto updateMovieDto)
        {
            updateMovieDto.MovieId = id;
            var result = await _movieService.UpdateAsync(updateMovieDto);
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var deleteMovieDto = new DeleteMovieDto { MovieId = id };
            var result = await _movieService.DeleteAsync(deleteMovieDto);
            if (!result)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
