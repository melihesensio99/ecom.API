using ETicaretAPI.Application.Dtos.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<TokenDto> LoginAsync(string UsernameOrEmai , string password);
    }
}
