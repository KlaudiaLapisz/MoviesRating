﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesRating.Application.Commands;
using MoviesRating.Application.DTO.Movies;
using MoviesRating.Application.Queries;
using Swashbuckle.AspNetCore.Annotations;
namespace MoviesRating.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(Roles ="admin")]
    public class MoviesController:ControllerBase
    {
        private readonly IMediator _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Get movies list")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetAll([FromQuery]GetAllMoviesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation("Get movie details by id")]
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Create new movie")]
        public async Task<ActionResult> Post (CreateMovieCommand command)
        {
            command.MovieId = Guid.NewGuid();
            await _mediator.Send(command);

            return CreatedAtAction(nameof(Get), new { id=command.MovieId }, null);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Update existing movie")]
        public async Task<ActionResult> Put (Guid id, UpdateMovieCommand command)
        {
            command.MovieId = id;
            await _mediator.Send(command);
            
            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Delete movie")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteMovieCommand { MovieId = id };
            await _mediator.Send(command);
            
            return NoContent();
        }
    }
}
