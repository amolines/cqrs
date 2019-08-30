using Microsoft.Extensions.Configuration;
using Xendor.CommandModel.EventSourcing;
using Xendor.CommandModel.EventSourcing.SnapShotting;
using Xendor.CommandModel.MySql.SnapShotting;
using Xendor.Data;
using Xendor.Data.Extensions;
using Xendor.Data.MySql;

using Xendor.ServiceLocator;

namespace Xendor.CommandModel.MySql.Extensions
{
    public static class EventSourcingMySqlServiceCollectionExtensions
    {
        public static void AddEventSourcingMySql(this IServiceLocator services, IConfiguration configuration, string key)
        {
            services.AddUnitOfWorkConnection<MySqlConnection>(configuration, key);
            services.Register<IUnitOfWorkFactory, MySqlUnitOfWorkFactory>();
            services.Register<IEventStorage, MySqlEventStorage>();
            services.Register<ISnapshotStorage, MySqlSnapshotStorage>();

        }

 

    }

    

}