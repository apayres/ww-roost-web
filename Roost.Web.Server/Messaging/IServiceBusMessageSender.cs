using Roost.Web.Server.Models;

namespace Roost.Web.Server.Messaging
{
    public interface IServiceBusMessageSender
    {
        void SendOrder(Order order);
    }
}