using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesRating.Application.Commands;
using MoviesRating.Application.DTO.Users;
using MoviesRating.Application.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace MoviesRating.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation("Get users list")]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll([FromQuery]GetAllUsersQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("me")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Return details off current logged in user")]
        public async Task<ActionResult<UserDto>> Get()
        {
            if (string.IsNullOrWhiteSpace(User.Identity?.Name))
            {
                return NotFound();
            }

            var userId = Guid.Parse(User.Identity?.Name);
            var user = await _mediator.Send(new GetUserByIdQuery() { UserId = userId });

            return Ok(user);
        }

        [HttpPost("sign-up")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation("Registration of new user")]
        public async Task<ActionResult> SignUp(SignUpCommand command)
        {
            command.UserId = Guid.NewGuid();
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("sign-in")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation("User login")]
        public async Task<ActionResult> SignIn(SingInCommand command)
        {
            var token = await _mediator.Send(command);

            return Ok(token);
        }

        [HttpPut("{id:guid}/change-password")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Change of user password")]
        public async Task<ActionResult> ChangePassword(Guid id, ChangePasswordCommand command)
        {
            command.UserId = id;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id:guid}/change-role")]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Change of user role")]
        public async Task<ActionResult> ChangeRole(Guid id, ChangeRoleCommand command)
        {
            command.UserId = id;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("{id:guid}/edit-user")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Update user data")]
        public async Task<ActionResult> EditUser(Guid id, EditUserCommand command)
        {
            command.UserId = id;
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [SwaggerOperation("Delete user")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand { UserId = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
