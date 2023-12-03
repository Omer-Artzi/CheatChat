using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRChatMVC.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    //public async Task SendMessage(string message)
    {
        // Broadcast the message to all clients
        await Clients.All.SendAsync("ReceiveMessage", user, message);
        //await Clients.All.SendAsync("ReceiveMessage", message);
    }
}
