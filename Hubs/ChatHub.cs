
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
    //public async Task ReturnBack(string user)
    //{
    //    //return to home page by calling chat controller method:
    //    //invoke("ReceiveMessage", user);
    //}




}
