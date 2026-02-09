using ETicaretAPI.Application.Dtos.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Command.AppUser.GoogleLogin
{
    public class GoogleLoginResponse
    {
        public TokenDto Token { get; set; }
    }
}
