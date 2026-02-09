using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Command.AppUser.GoogleLogin
{
    public class GoogleLoginRequest : IRequest<GoogleLoginResponse>
    {
        public string id { get; set; }
        public string idToken { get; set; }
        public string Email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Name { get; set; }
        public string photoUrl { get; set; }
        public string Provider { get; set; }
    }


}
