using api.Data.Models;
using Microsoft.AspNetCore.SignalR;

namespace api.SignalR
{
    public class Notificacion : Hub
    {
        public async Task  SendNotification(string message,string user)
        {
            await Clients.All.SendAsync("messageReceived", user, message);
        }

    }
}
