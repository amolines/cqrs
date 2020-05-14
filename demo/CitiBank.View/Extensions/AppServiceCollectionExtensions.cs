using System.Collections.Generic;
using System.Data.Common;
using CitiBank.View.Views.Accounts;
using CitiBank.View.Views.Accounts.Criterias;
using CitiBank.View.Views.Accounts.DataMappers;
using CitiBank.View.Views.Accounts.Dtos;
using Microsoft.Extensions.Configuration;
using Xendor.Extensions;
using Xendor.QueryModel.MySql;
using Xendor.QueryModel.QueryProcessor;
using Xendor.QueryModel.QueryProcessor.Infrastructure;
using Xendor.ServiceLocator;


namespace CitiBank.View.Extensions
{
    public static class AppServiceCollectionExtensions
    {

        public static void InitializeContainer(this IServiceLocator services, IConfiguration configuration)
        {
            services.AddXendor();


            services.RegisterSingleton<IQueryProcessorRegistry, QueryProcessorRegistry>();



            services.RegisterScoped<IQueryProcessor<AccountCriteria>, DbQueryProcessor<AccountCriteria, AccountQuery ,AccountDto >>();
            services.RegisterScoped<IQueryProcessor<OperationCriteria>, DbQueryProcessor<OperationCriteria, OperationsQuery, OperationDto>>();



            var settingsSection = configuration.GetSection("connectionString");
            var connection = settingsSection.Get<MySqlConnection>();
            services.Register<IConnection>(connection);
            /*Registro de Mappers*/
            services.RegisterSingleton<IDataMapper<AccountDto>, AccountDtoDataMapper>();
            services.RegisterSingleton<IDataMapper<OperationDto>, OperationDtoDataMapper>();
            /*Registro de la Base de datos*/
            services.RegisterScoped<IDataBase, MySqlDataBase>();
            /*Registro del repositorio*/
            services.RegisterScoped<IRepository<AccountDto>, Repository<AccountDto>>();
            services.RegisterScoped<IRepository<OperationDto>, Repository<OperationDto>>();





        }

    }

    

}