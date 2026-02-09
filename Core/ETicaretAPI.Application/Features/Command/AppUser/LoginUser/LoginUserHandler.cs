using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.Dtos.Token;
using ETicaretAPI.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Command.AppUser.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
        private readonly ITokenHandler _token;

        public LoginUserHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, SignInManager<Domain.Entities.Identity.AppUser> signInManager , ITokenHandler token)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _token = token;

        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
           var user = await _userManager.FindByNameAsync(request.UsernameOrEmail);
            if (user == null)
                await _userManager.FindByEmailAsync(request.UsernameOrEmail);
            if (user == null)
                throw new UserNotFoundException();

           var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)
            {
               TokenDto token = _token.CreateAccessToken();
                return new()
                {
                    Token = token
                };
            }
            throw new AuthenticationErrorException();
        }
    }
}
