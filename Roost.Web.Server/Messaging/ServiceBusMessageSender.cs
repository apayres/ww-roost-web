using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;
using Roost.Web.Server.Messaging.Configuration;
using Roost.Web.Server.Models;
using System.Text.Json;

namespace Roost.Web.Server.Messaging
{
    public class ServiceBusMessageSender : IServiceBusMessageSender
    {
        private readonly string _connection;

        public ServiceBusMessageSender(IOptions<ServiceBusOptions> options)
        {
            _connection = options.Value.ServiceBusConnectionString;
        }

        public void SendOrder(Order order)
        {
            var client = new ServiceBusClient(_connection);

            var message = new ServiceBusMessage();
            message.ApplicationProperties.Add("Author", "Adam");
            message.To = "Ordering System";
            message.Subject = "New Order";
            message.ContentType = "application/json";
            message.Body = new BinaryData(JsonSerializer.Serialize(order));

            var sender = client.CreateSender("orders");
            sender.SendMessageAsync(message).Wait();
        }
    }
}
