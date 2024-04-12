using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoviesRating.Application.Commands;
using MoviesRating.Application.DTO.Users;
using MoviesRating.Application.Queries;

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

        [HttpGet("me")]
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
        public async Task<ActionResult> SignUp(SignUpCommand command)
        {
            command.UserId = Guid.NewGuid();
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("sign-in")]
        public async Task<ActionResult> SignIn(SingInCommand command)
        {
            var token = await _mediator.Send(command);

            return Ok(token);
        }
    }
}
