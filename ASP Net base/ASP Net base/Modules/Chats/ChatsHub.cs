using Microsoft.AspNetCore.SignalR;

namespace ASP_Net_base.Modules.Chats
{
    public class ChatsHub : Hub
    {
        public async Task Send(string message)
        {
            await Clients.All.SendAsync("Receive", message);
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
