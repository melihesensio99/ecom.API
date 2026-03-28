using Microsoft.AspNetCore.SignalR;

namespace ETicaretAPI.SignalR.Hubs
{
    public class ProductHub : Hub
    {
        public async Task AddToGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
