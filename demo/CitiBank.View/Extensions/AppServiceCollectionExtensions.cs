using System.Collections.Generic;
using System.Data.Common;
using CitiBank.View.Views.Accounts;
using CitiBank.View.Views.Accounts.Criterias;
using CitiBank.View.Views.Accounts.DataMappers;
using CitiBank.View.Views.Accounts.Dtos;
using Microsoft.Extensions.Configuration;
using Xendor.Data;
using Xendor.Data.Extensions;
using Xendor.Data.MySql;
using Xendor.Extensions;
using Xendor.QueryModel;
using Xendor.QueryModel.Data;
using Xendor.QueryModel.Expressions;
using Xendor.ServiceLocator;

namespace CitiBank.View.Extensions
{
    public static class AppServiceCollectionExtensions
    {

        public static void InitializeContainer(this IServiceLocator services, IConfiguration configuration)
        {
            services.AddXendor();
            services.AddUnitOfWorkConnection<MySqlConnection>(configuration, "connectionString");
            services.Register<IUnitOfWorkManager, UnitOfWorkManager>();
            services.Register<IUnitOfWorkFactory, MySqlUnitOfWorkFactory>();



            services.Register<IQueryHandler<AccountCriteria>, DbQueryHandler<AccountCriteria, AccountDto, AccountQuery>>();
            services.Register<IEmbedQueryHandler<OperationDto>, DbEmbedQueryHandler<OperationDto,  OperationsQuery>>();

            services.Register<IDataMapper<DbDataReader, IEnumerable<AccountDto>>, AccountDtoDataMapper>();
            services.Register<IDataMapper<DbDataReader, IEnumerable<OperationDto>>, OperationDtoDataMapper>();

            services.Register<IFactoryExpression<ISelectQuery> , DbFactoryExpression>();

            services.Register<IQueryHandlerFactory, QueryHandlerFactory>();
            services.Register<IEmbedQueryHandlerFactory, EmbedQueryHandlerFactory>();
            services.Register<IQueryDispatcher,QueryDispatcher>();
        }

    }

    

}