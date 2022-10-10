using ECommerce.Project.Backend.Domain.Entities;
using Microsoft.AspNetCore.SignalR;

namespace ECommerce.Project.Backend.Web.Utils.Signal_Hub
{
    public class SignalHub : Hub
    {
        public void NotificationMessage(string message) 
        {
            Clients.All.SendAsync("NotificationMessage", message);
        }

        public void SendNotification(Customer customer) 
        {
            Clients.All.SendAsync("SendNotification", customer);
        }
    }
}
