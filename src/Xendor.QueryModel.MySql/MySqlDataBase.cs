
using Xendor.QueryModel.QueryProcessor.Infrastructure;

namespace Xendor.QueryModel.MySql
{
    public class MySqlDataBase : DataBase
    {
        public MySqlDataBase(string connectionString)
            : base(connectionString, Devart.Data.MySql.MySqlProviderFactory.Instance)
        {
        }
    }
}