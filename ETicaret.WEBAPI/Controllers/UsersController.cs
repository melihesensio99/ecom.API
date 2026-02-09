using ETicaretAPI.Application.Features.Command.AppUser.CreateUser;
using ETicaretAPI.Application.Features.Command.AppUser.GoogleLogin;
using ETicaretAPI.Application.Features.Command.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserRequest createUserRequest)
        {
            CreateUserResponse response = await _mediator.Send(createUserRequest);
            return Ok(response);
        }


    }
}
