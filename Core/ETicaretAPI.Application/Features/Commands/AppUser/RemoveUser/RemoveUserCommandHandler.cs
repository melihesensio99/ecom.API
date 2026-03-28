using ETicaretAPI.Application.Abstractions.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Application.Features.Commands.AppUser.RemoveUser
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommandRequest, RemoveUserCommandResponse>
    {
        readonly IUserService _userService;

        public RemoveUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<RemoveUserCommandResponse> Handle(RemoveUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userService.RemoveUserAsync(request.Id);
            return new()
            {
                Succeeded = result.Succeeded,
                Message = result.Succeeded ? "Kullanıcı başarıyla silindi." : "Kullanıcı silinirken bir hata oluştu."
            };
        }
    }
}
