using ETicaretAPI.Application.Features.Command.AppUser.GoogleLogin;
using ETicaretAPI.Application.Features.Command.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserRequest loginUserRequest)
        {
            var response = await _mediator.Send(loginUserRequest);
            return Ok(response);
        }

        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin(GoogleLoginRequest googleLoginRequest)
        {
            GoogleLoginResponse response = await _mediator.Send(googleLoginRequest);
            return Ok(response);
        }
    }
}
