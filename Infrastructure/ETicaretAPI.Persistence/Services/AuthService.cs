using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Application.Abstractions.User.CreateUser;
using ETicaretAPI.Application.Dtos.Token;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly IUserService _userService;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
            _userService = userService;
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
                    TokenDto token = _tokenHandler.CreateAccessToken(10 , user);
                await _userService.UpdateRefreshToken(token.RefreshToken, user, token.Expiration.Value, 900);
                    return token;
                }

            throw new AuthenticationErrorException();


        }

        public async Task<TokenDto> RefreshTokenLoginAsync(string refreshToken)
        {
           var user =  await _userManager.Users.FirstOrDefaultAsync(a => a.RefreshToken == refreshToken);
            if(user != null && user.RefreshTokenEndTime > DateTime.UtcNow)
            {
               var token = _tokenHandler.CreateAccessToken(30, user);  
                await _userService.UpdateRefreshToken(token.RefreshToken , user , token.Expiration.Value, 900);
                return token;
            }
            else
            {
                throw new UserNotFoundException();
            }

        }
    }
}
