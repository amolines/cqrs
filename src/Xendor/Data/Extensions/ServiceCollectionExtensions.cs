using Microsoft.Extensions.Configuration;
using Xendor.ServiceLocator;

namespace Xendor.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddUnitOfWorkConnection<TConnection>(this IServiceLocator services, IConfiguration configuration, string key)
            where TConnection : class, IUnitOfWorkConnection
        {
            var settingsSection = configuration.GetSection(key);
            var connection = settingsSection.Get<TConnection>();
            services.Register<IUnitOfWorkConnection>(connection);
        }
    }
}