using Microsoft.Extensions.Options;

namespace Roost.Web.Server.Messaging.Configuration
{
    public class ServiceBusOptions : IOptions<ServiceBusOptions>
    {
        public string ServiceBusConnectionString { get; set; }

        public ServiceBusOptions Value => this;
    }
}
