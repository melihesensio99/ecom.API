using MediatR;

namespace ETicaretAPI.Application.Features.Commands.AppUser.RemoveUser
{
    public class RemoveUserCommandRequest : IRequest<RemoveUserCommandResponse>
    {
        public string Id { get; set; }
    }
}
