using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoviesRating.Application.Commands;
using MoviesRating.Application.DTO.Directors;
using MoviesRating.Application.Services;

namespace MoviesRating.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectorsController:ControllerBase
    {
        private readonly IDirectorService _directorService;
        private readonly IMediator _mediator;

        public DirectorsController(IDirectorService directorService, IMediator mediator)
        {
            _directorService = directorService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectorDto>>> GetAll()
        {
            var result = await _directorService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<DirectorDto>> Get(Guid id)
        {
            var result = await _directorService.GetAsync(id);
            if (result==null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateDirectorCommand command)
        {
            command.DirectorId = Guid.NewGuid();
            await _mediator.Send(command);
            
            return CreatedAtAction(nameof(Get), new { id=command.DirectorId }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, UpdateDirectorDto updateDirectorDto)
        {
            updateDirectorDto.DirectorId = id;
            await _directorService.UpdateAsync(updateDirectorDto);
           
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteDirectorCommand { DirectorId = id };
            await _mediator.Send(command);
           
            return NoContent();
        }
    }
}
