using ETicaretAPI.Application.Dtos.User;
using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.User.CreateUser
{
    public interface IUserService
    {
        Task<CreateUserResponseDto> CreateUserAsync(CreateUserDto model);
        Task UpdateRefreshToken(string refreshToken , AppUser user , DateTime accesTokenDate , int addDate);
    }
}
