using ETicaretAPI.Application.Abstractions.Services.Authentications;
using ETicaretAPI.Application.Dtos.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Services
{
    public interface IAuthService : IExternalAuthentication , IInternalAuthentication
    {
        Task<TokenDto> RefreshTokenLoginAsync(string refreshToken);
    }
}
