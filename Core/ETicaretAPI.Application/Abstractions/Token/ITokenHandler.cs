using ETicaretAPI.Application.Dtos.Token;
using ETicaretAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
      TokenDto CreateAccessToken(int second, AppUser appUser);
        string CreateRefreshToken();

    }
}
