using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoviesRating.Application.Commands;
using MoviesRating.Application.DTO.Genres;
using MoviesRating.Application.Services;

namespace MoviesRating.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenresController:ControllerBase
    {
        private readonly IGenreService _genreService;
        private readonly IMediator _mediator;

        public GenresController(IGenreService genreService, IMediator mediator)
        {
            _genreService = genreService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetAll()
        {
            var result = await _genreService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GenreDto>> Get(Guid id)
        {
            var result= await _genreService.GetAsync(id);
            if(result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post (CreateGenreCommand command)
        {
            command.GenreId = Guid.NewGuid();
            await _mediator.Send(command);
            
            return CreatedAtAction(nameof(Get), new { id = command.GenreId }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, UpdateGenreCommand command)
        {
            command.GenreId = id;
            await _mediator.Send(command);
            
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteGenreCommand { GenreId = id };
            await _mediator.Send(command);
            
            return NoContent();
        }
    }
}
