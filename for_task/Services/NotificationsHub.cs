using Microsoft.AspNetCore.SignalR;

namespace for_task.Services
{
    public class NotificationsHub : Hub
    {
        //Broadcast a message to every connected user.
        public async Task BroadcastMessage(Object[] messages)
        {
            await this.Clients.All.SendAsync("message_received", messages);
        }

    }
}
