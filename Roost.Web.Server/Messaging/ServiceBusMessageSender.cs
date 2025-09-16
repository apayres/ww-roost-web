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
            // Service Client
            var client = new ServiceBusClient(_connection);

            // Compose our message
            var message = new ServiceBusMessage();
            message.ApplicationProperties.Add("Author", "Roost Web Application");
            message.ApplicationProperties.Add("Reason", "Customer Order");

            message.To = "Order System";
            message.Subject = "New Order";
            message.ContentType = "application/json";
            message.Body = new BinaryData(JsonSerializer.Serialize(order));

            // Create the message sender 
            var sender = client.CreateSender("orders");

            // Send message
            sender.SendMessageAsync(message).Wait();            
        }
    }
}
