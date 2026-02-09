using ETicaretAPI.Application.Dtos.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Command.AppUser.LoginUser
{
    public class LoginUserResponse
    {
        public TokenDto Token { get; set; }
        public string Message { get; set; }
    }
}
