using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoviesRating.Application.Commands;

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
