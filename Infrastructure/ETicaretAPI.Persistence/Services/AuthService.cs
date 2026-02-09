using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.Dtos.Token;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenHandler _tokenHandler;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }

        public async Task<TokenDto> LoginAsync(string UsernameOrEmail, string password)
        {
            var user =await _userManager.FindByEmailAsync(UsernameOrEmail);
            if (user == null)
            {
               user = await _userManager.FindByNameAsync(UsernameOrEmail);
                if (user == null)
                    throw new UserNotFoundException();

            }
               var result = await _signInManager.CheckPasswordSignInAsync(user , password , false);
                if (result.Succeeded)
                {
                    TokenDto token = _tokenHandler.CreateAccessToken(5 , user);
                    return token;
                }

            throw new AuthenticationErrorException();


        }
    }
}
