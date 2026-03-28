using ETicaretAPI.Application.Abstractions.Hubs;
using ETicaretAPI.SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.SignalR.HubServices
{
    public class ProductHubService : IProductHubService
    {
        private readonly IHubContext<ProductHub> _hubContext;

        public ProductHubService(IHubContext<ProductHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task ProductAddedMessageAsync(string message)
        {
            await _hubContext.Clients.Group("Admins").SendAsync(ReceiveFunctionNames.ProductAddedMessage, message);
        }

        public async Task ProductLowStockMessageAsync(string message)
        {
            await _hubContext.Clients.Group("Admins").SendAsync(ReceiveFunctionNames.ProductLowStockMessage, message);
        }
    }
}
