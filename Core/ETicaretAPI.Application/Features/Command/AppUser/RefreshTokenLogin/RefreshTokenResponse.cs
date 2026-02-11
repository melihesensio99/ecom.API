using ETicaretAPI.Application.Dtos.Token;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Command.AppUser.RefreshTokenLogin
{
    public class RefreshTokenResponse
    {
        public TokenDto Token { get; set; }
    }
}
