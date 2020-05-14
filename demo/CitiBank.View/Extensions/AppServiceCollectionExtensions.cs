using System.Collections.Generic;
using System.Data.Common;
using CitiBank.View.Views.Accounts;
using CitiBank.View.Views.Accounts.Criterias;
using CitiBank.View.Views.Accounts.DataMappers;
using CitiBank.View.Views.Accounts.Dtos;
using Microsoft.Extensions.Configuration;
using Xendor.Extensions;
using Xendor.QueryModel;
using Xendor.QueryModel.Data;
using Xendor.QueryModel.MySql;
using Xendor.ServiceLocator;


namespace CitiBank.View.Extensions
{
    public static class AppServiceCollectionExtensions
    {

        public static void InitializeContainer(this IServiceLocator services, IConfiguration configuration)
        {
            services.AddXendor();


            services.RegisterSingleton<IQueryHandlerFactory, QueryHandlerFactory>();
            services.RegisterSingleton<IEmbedQueryHandlerFactory, EmbedQueryHandlerFactory>();
            services.RegisterSingleton<IQueryDispatcher, QueryDispatcher>();
            services.RegisterSingleton<IDataMapper<DbDataReader, IEnumerable<AccountDto>>, AccountDtoDataMapper>();
            services.RegisterSingleton<IDataMapper<DbDataReader, IEnumerable<OperationDto>>, OperationDtoDataMapper>();
            services.RegisterSingleton<IFactoryExpression<ISelectQuery>, DbFactoryExpression>();

            services.RegisterScoped<IQueryHandler<AccountCriteria>, DbQueryHandler<AccountCriteria, AccountDto, AccountQuery>>();
            services.RegisterScoped<IEmbedQueryHandler<OperationDto>, DbEmbedQueryHandler<OperationDto, OperationsQuery>>();



            var settingsSection = configuration.GetSection("connectionString");
            var connection = settingsSection.Get<MySqlConnection>();
            services.Register<IConnection>(connection);

            services.RegisterScoped<IDataBase, MySqlDataBase>();



         
          

            
            
        }

    }

    

}