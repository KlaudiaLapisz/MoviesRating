using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesRating.Application.Commands;
using MoviesRating.Application.DTO.Directors;
using MoviesRating.Application.Queries;

namespace MoviesRating.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles ="admin")]
    public class DirectorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DirectorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DirectorDto>>> GetAll([FromQuery]GetAllDirectorsQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<ActionResult<DirectorDto>> Get(Guid id)
        {
            var result = await _mediator.Send(new GetDirectorByIdQuery() { Id = id });
            if (result == null)
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

            return CreatedAtAction(nameof(Get), new { id = command.DirectorId }, null);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, UpdateDirectorCommand command)
        {
            command.DirectorId = id;
            await _mediator.Send(command);

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
