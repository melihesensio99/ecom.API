using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Domain.Entities.Identity;
using Google.Apis.Auth;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace ETicaretAPI.Application.Features.Command.AppUser.GoogleLogin
{
    public class GoogleLoginHandler : IRequestHandler<GoogleLoginRequest, GoogleLoginResponse>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
        private readonly ITokenHandler _tokenHandler;

        public GoogleLoginHandler(UserManager<Domain.Entities.Identity.AppUser> userManager , ITokenHandler tokenHandler)
        {
            _userManager = userManager;
             _tokenHandler = tokenHandler;
        }

        public async Task<GoogleLoginResponse> Handle(GoogleLoginRequest request, CancellationToken cancellationToken)
        {
            ValidationSettings settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string>() { "564293114298-af3241aafm5bdc49cl7comtncn5dnvhh.apps.googleusercontent.com" }
            };

            var payload = await GoogleJsonWebSignature.ValidateAsync(request.idToken, settings);
            var info = new UserLoginInfo(request.Provider, payload.Subject, request.Provider);
            var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);
           
            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new()
                    {

                        Id = Guid.NewGuid().ToString(),
                        Email = payload.Email,
                        UserName = payload.Email,
                        NameSurname = payload.Name
                    };
                   var createResult= await _userManager.CreateAsync(user);
                   result = createResult.Succeeded;
                }
            }
            if (result)
                await _userManager.AddLoginAsync(user, info);
            else
            {
                throw new Exception("sistemsel hata");
            }

            var token = _tokenHandler.CreateAccessToken(5 , user);

            return new GoogleLoginResponse()
            {
                Token = token
            };



            }
        }
    }

