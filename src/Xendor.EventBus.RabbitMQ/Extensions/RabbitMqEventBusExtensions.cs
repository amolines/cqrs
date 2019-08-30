using Microsoft.Extensions.Configuration;
using Xendor.ServiceLocator;

namespace Xendor.EventBus.RabbitMQ.Extensions
{
    public static class RabbitMqEventBusExtensions
    {
        public static void AddRabbitMqEventBus(this IServiceLocator services, IConfiguration configuration, string key)
        {
            var settingsSection = configuration.GetSection(key);
            var connection = settingsSection.Get<RabbitMqConnectionString>();

            services.Register(connection);
            services.Register<IEventBus, RabbitMqEventBus>();
        }
    }
}