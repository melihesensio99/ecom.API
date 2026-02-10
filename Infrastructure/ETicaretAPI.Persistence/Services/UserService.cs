using ETicaretAPI.Application.Abstractions.User.CreateUser;
using ETicaretAPI.Application.Dtos.User;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Google.Apis.Requests.BatchRequest;

namespace ETicaretAPI.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateUserResponseDto> CreateUserAsync(CreateUserDto model)
        {
           var data = await _userManager.CreateAsync(new()
            {
               Id = Guid.NewGuid().ToString(),
               Email = model.Email,
                UserName = model.Username,
                NameSurname = model.NameSurname,

            } , model.Password);

            var result = new CreateUserResponseDto()
            {
                 Succeeded = data.Succeeded
            };

            if (result.Succeeded) 
            {
                result.Message = "KUllanici başariyla oluşturuldu";
            }
            else
            {
                foreach (var error in data.Errors)
                   result.Message += $"{error.Code} - {error.Description}";
            };
           
            return result;

        }
        public async Task UpdateRefreshToken(string refreshToken, AppUser user, DateTime accesTokenDate, int addDate)
        {
            var data = await _userManager.FindByIdAsync(user.Id);
            if (data != null)
            {
                data.RefreshToken = refreshToken;
                data.RefreshTokenEndTime = accesTokenDate.AddSeconds(addDate);
                await _userManager.UpdateAsync(user);
            }
            else
            {
                throw new UserNotFoundException();
            }

                
        }
    }
}
