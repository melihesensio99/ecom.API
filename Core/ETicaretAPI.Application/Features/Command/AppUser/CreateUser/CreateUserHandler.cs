using ETicaretAPI.Application.Abstractions.User.CreateUser;
using ETicaretAPI.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ETicaretAPI.Application.Features.Command.AppUser.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {

        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var result =await _userService.CreateUserAsync(new()
            {
                Email = request.Email,
                NameSurname = request.NameSurname,
                Username = request.Username,
                Password = request.Password,
            });

            return new()
            {
                Message = result.Message,
                Succeeded = result.Succeeded,
            };

        }
    }
}
