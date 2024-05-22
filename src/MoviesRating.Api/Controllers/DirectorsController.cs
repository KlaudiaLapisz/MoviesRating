using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesRating.Application.Commands;
using MoviesRating.Application.DTO.Directors;
using MoviesRating.Application.Queries;
using Swashbuckle.AspNetCore.Annotations;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Get directors list")]
        public async Task<ActionResult<IEnumerable<DirectorDto>>> GetAll([FromQuery]GetAllDirectorsQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Get director details by id")]
        public async Task<ActionResult<DirectorDto>> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetDirectorByIdQuery() { Id = id }, cancellationToken);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Create new director")]
        public async Task<ActionResult> Post(CreateDirectorCommand command, CancellationToken cancellationToken)
        {
            command.DirectorId = Guid.NewGuid();
            await _mediator.Send(command, cancellationToken);

            return CreatedAtAction(nameof(Get), new { id = command.DirectorId }, null);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Update existing director")]
        public async Task<ActionResult> Put(Guid id, UpdateDirectorCommand command, CancellationToken cancellationToken)
        {
            command.DirectorId = id;
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Delete director")]
        public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteDirectorCommand { DirectorId = id };
            await _mediator.Send(command, cancellationToken);

            return NoContent();
        }
    }
}
