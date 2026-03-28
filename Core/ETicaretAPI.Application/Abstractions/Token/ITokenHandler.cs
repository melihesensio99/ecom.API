using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Domain.Entities.Identity;

namespace ETicaretAPI.Application.Abstractions.Tokens
{
    public interface ITokenHandler
    {
        Token CreateAccessToken(int second, AppUser appUser);
        string CreateRefreshToken();
    }
}
