
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRChatMVC.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        // Broadcast the message to all clients
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
    // public async Task ReturnBack(string user)
    // {
    //    // Send a message to the client to navigate back to the home view
    //     await Clients.All.SendAsync("NavigateHome", user);
    //     //change to  the current user only
    // }




}
